using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Studio.DotNet.Domain;

// ReSharper disable ClassNeverInstantiated.Global
namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 文章数据访问层
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
	public class TblArticleDal : IDal.ITblArticleDal
	{
		private readonly IDbConnection _db;
		public TblArticleDal(IDbConnection db)
		{
			_db = db;
		}
		public async Task<int> InsertAsync(Domain.TblArticle article)
		{
			return await _db.QueryFirstAsync<int>(@"
				--添加一个文章主体
				INSERT INTO [dbo].[TblArticle]
						   ([Title]
						   ,[Description]
						   ,[ContentUrl])
					 VALUES
						   (@Title
						   ,@Description
						   ,@ContentUrl);
				DECLARE @ArticleId INT;
				SELECT @ArticleId = @@IDENTITY;
				", new { article.Title, article.Description, article.ContentUrl});	// TODO lianggejieguo
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}
		public Task<int> UpdateAsync(Domain.TblArticle model)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 获取单个用户
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<Domain.TblArticle> GetOrDefaultAsync(int id)
		{
			return _db.QueryFirstAsync<Domain.TblArticle>(@"
				SELECT *
				FROM dbo.TblArticle
				WHERE Id = @id
			", new { id });
		}

		public Task<TblArticle> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticle> GetAsync(string field)
		{
			throw new NotImplementedException();
		}

		public Task<TblArticle> GetOrDefaultAsync(string field)
		{
			throw new NotImplementedException();
		}
	}
}
