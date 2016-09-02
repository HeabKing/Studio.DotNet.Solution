using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studio.DotNet.Domain;

namespace Studio.DotNet.Dal
{
    public class TblArticleTblTagDal:IDal.ITblArticleTblTagDal
    {
	    public Task<int> InsertAsync(TblArticleTblTag model)
	    {
		    throw new NotImplementedException();
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
