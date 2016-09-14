using System;
using System.Threading.Tasks;
using Studio.DotNet.Domain;
using Dapper;
namespace Studio.DotNet.Dal
{
	// ReSharper disable once ClassNeverInstantiated.Global
    public class TblUserTblArticleDal:IDal.ITblUserTblArticleDal
    {
	    private readonly System.Data.IDbConnection _db;
	    public TblUserTblArticleDal(System.Data.IDbConnection db)
	    {
			_db = db;
	    }
	    public Task<int> InsertAsync(TblUserTblArticle model)
	    {
		    return _db.QueryFirstAsync<int>(@"
				INSERT INTO dbo.TblUserTblArticle
						( AuthorId ,
						  ArticleId 
						)
				VALUES  ( 0 ,
						  0 
						);
				SELECT @@IDENTITY;");
	    }

	    public Task<int> DeleteAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<int> UpdateAsync(TblUserTblArticle model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUserTblArticle> GetOrDefaultAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUserTblArticle> GetAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUserTblArticle> GetAsync(string field)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblUserTblArticle> GetOrDefaultAsync(string field)
	    {
		    throw new NotImplementedException();
	    }
    }
}
