using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
// ReSharper disable ClassNeverInstantiated.Global
namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 文章数据访问层
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
    public class TblArticleDal:IDal.ITblArticleDal
	{
		private readonly IDbConnection _db;
		public TblArticleDal(IDbConnection db)
		{
			_db = db;
		}
	    public Task<int> InsertAsync(Domain.TblArticleDto model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<int> DeleteAsync(int id)
	    {
		    throw new NotImplementedException();
	    }
	    public Task<int> UpdateAsync(Domain.TblArticleDto model)
	    {
		    throw new NotImplementedException();
	    }

		/// <summary>
		/// 获取单个用户
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
	    public Task<Domain.TblArticleDto> GetAsync(int id)
	    {
		    return _db.QueryFirstAsync<Domain.TblArticleDto>(@"
				SELECT *
				FROM dbo.TblArticle
				WHERE Id = @id
			", new {id});
	    }
    }
}
