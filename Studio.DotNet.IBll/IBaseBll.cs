using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IBll
{
    public interface IBaseBll<T>
    {
        Task<int> AddAsync(T model);
        Task<bool> RemoveAsync(int id);
        Task<bool> EditAsync(T model);
        Task<T> GetAsync(int id);
    }
}
