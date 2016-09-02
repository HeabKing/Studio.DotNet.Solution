using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// ReSharper disable once ClassNeverInstantiated.Global
namespace Studio.DotNet.CompositionRoot
{
	public class Startup
	{
		public Startup(IHostingEnvironment env){}
		//public IConfigurationRoot Configuration { get; }
		// This method gets called by the runtime. Use this method to add services to the container
		public static void ConfigureServices(IServiceCollection services)
		{
			// 添加中间件服务
			services.AddTransient<IDbConnection>(_ => new SqlConnection("Data Source=.;Initial Catalog=DbDotNetStudio;User Id=Sinx;Password=123;"));	 // HACK 一个请求用完要回收
			// 用户
			// Transient 每次使用服务都会创建一个
			services.AddTransient<IDal.ITbUserDal, Dal.TblUserDal>();
			services.AddTransient<IBll.IUserBll, Bll.UserBll>();
			// 文章
			services.AddTransient<IDal.ITblArticleDal, Dal.TblArticleDal>();
			services.AddTransient<IBll.IAritlceBll, Bll.ArticleBll>();
			// 标签
			services.AddTransient<IDal.ITblTagDal, Dal.TblTagDal>();
			// 文章 <-> 标签
			services.AddTransient<IDal.ITblArticleTblTagDal, Dal.TblArticleTblTagDal>();
			// 用户 <-> 文章
			services.AddTransient<IDal.ITblUserTblArticleDal, Dal.TblUserTblArticleDal>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory){}
	}
}
