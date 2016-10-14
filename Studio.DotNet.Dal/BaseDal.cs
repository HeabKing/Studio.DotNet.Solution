using System;
using System.Collections.Generic;
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
	public class BaseDal<T> : IDal.IBaseDal<T>
	{
		private readonly System.Data.IDbConnection _db;
		private readonly string _tableName;

		public BaseDal(System.Data.IDbConnection db, string tableName)
		{
			if (db == null) { throw new ArgumentNullException(nameof(db)); }
			if (string.IsNullOrWhiteSpace(tableName)) { throw new ArgumentException(nameof(tableName)); }
			_db = db;
			_tableName = tableName;
		}

		/// <summary>
		/// 获取指定条件下的数据集合
		/// </summary>
		/// <param name="model">指定条件</param>
		/// <returns>没有值返回空集合</returns>
		public Task<IEnumerable<T>> GetAsync(T model)
		{
			var fileds = model.GetAssignedProperties().ToList();

			if (!fileds.Any())
			{
				throw new ArgumentException("请输入最少一个查询条件");
			}

			var sql = $@"
				SELECT *
				FROM {_tableName}
				WHERE 1 = 1";
			sql = fileds.Aggregate(sql, (c, i) => c + $" AND {i.Key} = @{i.Key} ");
			return _db.QueryAsync<T>(sql, model);
		}

		/// <summary>
		/// 添加一条数据
		/// </summary>
		/// <param name="model"></param>
		/// <returns>添加数据的Id</returns>
		public Task<int> InsertAsync(T model)
		{
			var assignedProperties = model.GetAssignedProperties().ToList();
			var assignedPropertyKeys = assignedProperties.Select(m => m.Key).ToList();
			string sql = $@"
				INSERT INTO [dbo].[{_tableName}]
					({string.Join(",", assignedPropertyKeys)})
				VALUES
					(@{string.Join(",@", assignedPropertyKeys)});
				SELECT @@IDENTITY;";
			return _db.QueryFirstAsync<int>(sql, model);
		}

		public Task<int> UpdateAsync(T model)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
