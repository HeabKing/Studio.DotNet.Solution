using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Bll
{
    public class BaseBll<T> : IBll.IBaseBll<T> where T : class
    {
	    private readonly IDal.IBaseDal<T> _dal;

	    protected BaseBll(IDal.IBaseDal<T> dal)
		{
			_dal = dal;
		}
	    public virtual Task<int> AddAsync(T model)
	    {
		    return _dal.InsertAsync(model);
	    }

	    public Task<bool> EditAsync(T model, T @where)
	    {
		    throw new NotImplementedException();
	    }

	    public Task<bool> RemoveAsync(T model)
	    {
		    throw new NotImplementedException();
	    }

	    public virtual async Task<bool> RemoveAsync(int id)
	    {
		    //return await _dal.DeleteAsync(id) == id; todo
		    return await Task.FromResult(false);
	    }

		public virtual async Task<bool> EditAsync(T model)
	    {
			//return await _dal.UpdateAsync(model) == 1;
			throw new NotImplementedException();
		}

		public virtual Task<IEnumerable<T>> GetAsync(T model)
	    {
		    return _dal.GetAsync(model);
	    }
    }
}
