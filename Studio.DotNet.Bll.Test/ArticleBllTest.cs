using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Studio.DotNet.Bll.Test
{
    public class ArticleBllTest
    {
	    private readonly IBll.IAritlceBll _articleBll;
		public ArticleBllTest()
		{
			IServiceCollection services = new ServiceCollection();
			CompositionRoot.Startup.ConfigureServices(services);
			_articleBll = services.BuildServiceProvider().GetService<IBll.IAritlceBll>();
		}

		[Fact]
	    public void GetAsync()
	    {
		    int id = 1;
		    var article = _articleBll.GetAsync(id).Result;
		    Assert.True(id == article.Id);
		    Assert.NotNull(article.ContentUrl);
	    }
    }
}
