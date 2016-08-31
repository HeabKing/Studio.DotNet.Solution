using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studio.DotNet.Domain;

namespace Studio.DotNet.Bll
{
    public class ArticleBll : IBll.IAritlceBll
    {
	    private readonly IDal.ITblArticleDal _articleDal;
		public ArticleBll(IDal.ITblArticleDal dal)
		{
			_articleDal = dal;
		}
	    public Task<bool> AddAsync(TblArticleDto model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<bool> RemoveAsync(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<bool> EditAsync(TblArticleDto model)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<TblArticleDto> GetAsync(int id)
	    {
		    return _articleDal.GetAsync(id);
	    }
    }
}
