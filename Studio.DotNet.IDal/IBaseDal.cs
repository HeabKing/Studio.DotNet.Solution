using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IDal
{
    public interface IBaseDal<T>
    {
        Task<int> InsertAsync(T model);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T model);
        Task<T> GetAsync(int id);
    }
}
