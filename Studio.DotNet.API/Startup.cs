using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// ReSharper disable ClassNeverInstantiated.Global
namespace Studio.DotNet.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();  // TODO MVC 没有?
            Configuration = builder.Build();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            // 添加自定义中间件 2016-08-31 Sinx
            CompositionRoot.Startup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            // 2016-09-01 添加异常处理程序
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            // 2016-09-19 Authentication 中间件
            // my own identity based on Microsoft.AspNetCore.Authentication.Cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "DotNetStudio.Login",    // this scheme name
                LoginPath = new PathString("/Api/Account/Cookie/"),   // if has not been authenticated, redirect to login path
                                                                      // PathString: provides correct escoping path
                AccessDeniedPath = new PathString("/Api/Account/Forbidden/"),   // if user attmpt to access but does not pass the authorization policies
                AutomaticAuthenticate = true,   // true: middleware run on every request and attempt to validate and reconstruct any serialized principal it created
                AutomaticChallenge = true   // challenge 质询, redirect browser to the LoginPath/AccessDeniedPath when authorization fails.
            });


            // WebAPI此方法没有里面的lambda参数
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
