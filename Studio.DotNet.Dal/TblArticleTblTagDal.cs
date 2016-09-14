using System;
using System.Data;
using System.Threading.Tasks;
using Studio.DotNet.Domain;
using Dapper;
namespace Studio.DotNet.Dal
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class TblArticleTblTagDal : IDal.ITblArticleTblTagDal
	{
		private readonly IDbConnection _db;
		public TblArticleTblTagDal(IDbConnection db)
		{
			_db = db;	
		}
		public Task<int> InsertAsync(TblArticleTblTag model)
		{
			return _db.QueryFirstAsync<int>(@"
				INSERT INTO dbo.TblArticleTblTag
						( ArticleId ,
						  TagId)
				VALUES  ( @ArticleId,
						  @TagId);
				SELECT @@IDENTITY;", model);
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(TblArticleTblTag model)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticleTblTag> GetOrDefaultAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticleTblTag> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticleTblTag> GetAsync(string field)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticleTblTag> GetOrDefaultAsync(string field)
		{
			throw new NotImplementedException();
		}
	}
}
