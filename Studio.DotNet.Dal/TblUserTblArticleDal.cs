using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studio.DotNet.Domain;

namespace Studio.DotNet.Dal
{
    public class TblUserTblArticleDal:IDal.ITblUserTblArticleDal
    {
	    public Task<int> InsertAsync(TblUserTblArticle model)
	    {
		    throw new NotImplementedException();
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
