using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;

namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 数据访问通用逻辑
	/// </summary>
	/// <typeparam name="T">Sinx 2016-10-12</typeparam>
	public class BaseDal<T> : IDal.IBaseDal<T> where T : class
	{
		private readonly System.Data.IDbConnection _db;
		private readonly string _tableName;

		public BaseDal(System.Data.IDbConnection db, string tableName)
		{
			if (db == null) { throw new ArgumentNullException(nameof(db)); }
			_db = db;
			_tableName = tableName;
		}

		/// <summary>
		/// 获取指定条件下的数据集合
		/// </summary>
		/// <param name="model">指定条件</param>
		/// <param name="defaultFields">按照默认值查询的字段</param>
		/// <returns>没有值返回空集合</returns>
		public Task<IEnumerable<T>> GetAsync(T model, params string[] defaultFields)
		{
			return _db.GetAsync(model, defaultFields);
		}

		/// <summary>
		/// 根据Id查询实体
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<T> GetAsync(int id)
		{
			return _db.GetAsync<T>(id);
		}

		/// <summary>
		/// 添加一条数据
		/// </summary>
		/// <param name="model"></param>
		/// <returns>添加数据的Id</returns>
		public Task<int> InsertAsync(T model)
		{
			return _db.InsertAsync(model);
		}

		public Task<int> UpdateAsync(T model, T where)
		{
			return _db.UpdateAsync(model, where);
		}

		public Task<int> UpdateAsync(T model)
		{
			return _db.UpdateAsync(model);
		}

		public Task<int> DeleteAsync(T model)
		{
			return IDbConnectionEx.DeleteAsync(_db, model);
		}
	}
}
