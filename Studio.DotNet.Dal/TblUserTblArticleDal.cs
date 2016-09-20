using System;
using System.Threading.Tasks;
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
	    public Task<int> InsertAsync(Domain.TblUserTblArticle model)
	    {
		    return _db.QueryFirstAsync<int>(@"
				INSERT INTO dbo.TblUserTblArticle
						( AuthorId ,
						  ArticleId 
						)
				VALUES  ( @AuthorId ,
						  @ArticleId 
						);
				SELECT @@IDENTITY;", model);
	    }

	    public Task<int> DeleteAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<int> UpdateAsync(Domain.TblUserTblArticle model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<Domain.TblUserTblArticle> GetOrDefaultAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<Domain.TblUserTblArticle> GetAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

        public Task<Domain.TblUserTblArticle> GetAsync(Domain.TblUserTblArticle model)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.TblUserTblArticle> GetOrDefaultAsync(Domain.TblUserTblArticle model)
        {
            throw new NotImplementedException();
        }
    }
}
