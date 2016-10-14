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
		Task<IEnumerable<T>> GetAsync(T model);
		Task<int> InsertAsync(T model);
		/// <summary>
		/// 返回受影响行数
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> UpdateAsync(T model);
		/// <summary>
		/// 返回被删除的Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<int> DeleteAsync(int id);
    }
}
