using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IBll
{
    public interface IBaseBll<T>
    {
		Task<IEnumerable<T>> GetAsync(T model);
		Task<int> AddAsync(T model);
		Task<bool> EditAsync(T model, T where);
        Task<bool> RemoveAsync(T model);
	}
}
