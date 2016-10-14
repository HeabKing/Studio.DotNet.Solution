using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Bll
{
    public class BaseBll<T> : IBll.IBaseBll<T>
    {
	    private readonly IDal.IBaseDal<T> _dal;
		public BaseBll(IDal.IBaseDal<T> dal)
		{
			_dal = dal;
		}
	    public virtual Task<int> AddAsync(T model)
	    {
		    return _dal.InsertAsync(model);
	    }

		public virtual async Task<bool> RemoveAsync(int id)
	    {
		    return await _dal.DeleteAsync(id) == id;
	    }

		public virtual async Task<bool> EditAsync(T model)
	    {
		    return await _dal.UpdateAsync(model) == 1;
	    }

		public virtual Task<IEnumerable<T>> GetAsync(T model)
	    {
		    return _dal.GetAsync(model);
	    }
    }
}
