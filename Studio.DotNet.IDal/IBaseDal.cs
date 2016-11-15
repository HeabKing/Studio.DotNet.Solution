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
	    /// <summary>
	    /// 获取指定条件下的实体集合
	    /// </summary>
	    /// <param name="model">查询的条件, 非默认值会被认为是条件</param>
	    /// <param name="defaultFields">按默认值查询的字段</param>
	    /// <returns></returns>
	    Task<IEnumerable<T>> GetAsync(T model, params string[] defaultFields);

		/// <summary>
		/// 返回添加行的Id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> InsertAsync(T model);

	    /// <summary>
	    /// 返回受影响行数
	    /// </summary>
	    /// <param name="model"></param>
	    /// <param name="where">对指定条件下的实体进行更新</param>
	    /// <returns></returns>
	    Task<int> UpdateAsync(T model, T where);

		/// <summary>
		/// 返回受影响的函数
		/// </summary>
		/// <returns></returns>
		Task<int> DeleteAsync(T model);
    }
}
