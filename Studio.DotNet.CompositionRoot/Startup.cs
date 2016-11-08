using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable once ClassNeverInstantiated.Global
namespace Studio.DotNet.CompositionRoot
{
	public class Startup
	{
		public static void ConfigureServices(IServiceCollection services)
		{
            // 添加中间件服务
            services.AddTransient<IDbConnection>(_ => new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DbDotNetStudio;User Id=sa;Password=123;"));	 // HACK 一个请求用完要回收
			// 用户
			services.AddTransient<IDal.ITblUserDal, Dal.TblUserDal>();
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
	}
}
