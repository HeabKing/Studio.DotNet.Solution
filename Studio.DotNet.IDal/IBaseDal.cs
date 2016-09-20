using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IDal
{
	/// <summary>
	/// 数据访问基接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>Sinx 2016-08-31</remarks>
    public interface IBaseDal<T>
    {
        Task<int> InsertAsync(T model);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T model);
        Task<T> GetOrDefaultAsync(int id);
	    Task<T> GetAsync(int id);
	    Task<T> GetAsync(T model);
	    Task<T> GetOrDefaultAsync(T model);
    }
}
