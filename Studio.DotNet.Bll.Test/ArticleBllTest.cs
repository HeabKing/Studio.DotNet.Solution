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
	    private readonly IDal.ITblTagDal _tagDal;
		public ArticleBllTest()
		{
			IServiceCollection services = new ServiceCollection();
			CompositionRoot.Startup.ConfigureServices(services);
			var s = services.BuildServiceProvider();
			_articleBll = s.GetService<IBll.IAritlceBll>();
			_tagDal = s.GetService<IDal.ITblTagDal>();
		}

		[Fact]
	    public void GetAsync()
	    {
		    int id = 1;
		    var article = _articleBll.GetAsync(new Domain.TblArticle {Id = id}).Result.FirstOrDefault();
		    Assert.True(id == article?.Id);
		    Assert.NotNull(article?.ContentUrl);
	    }

		/// <summary>
		/// 文章添加
		/// </summary>
		[Fact]
	    public void PostAsync()
		{
			var article = new Domain.TblArticle {  Title = DateTime.Now.ToString(), Description = "", ContentUrl = "/article/html/636083463437939905/636083463437939905.html"};
			var tags = new List<Domain.TblTag> { new Domain.TblTag { Value = "编程日记"}, new Domain.TblTag { Value = "DotNet" } };
			int userId = 1;
			var articleId = _articleBll.AddAsync(article, tags, userId).Result;
			Assert.True(articleId > 0);
			tags.ToList().ForEach(t => Assert.True(_tagDal.GetAsync(t).Result.FirstOrDefault()?.Id > 0));
		}
    }
}
