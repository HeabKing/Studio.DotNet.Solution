using System;
using System.Collections.Generic;
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
	public class BaseDal<T> : IDal.IBaseDal<T>
	{
		private readonly System.Data.IDbConnection _db;
		private readonly string _tableName;

		// Model => field = @field, field2 = @field2...
		private readonly Func<IEnumerable<string>, string, string> _tempDelegate =
			(ie, salt) => ie
				.Aggregate("", (c, i) => c + i + " = @" + i + (salt ?? "") + ",")
				.TrimEnd(',');

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
		/// 根据Id查询实体
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<T> GetAsync(int id)
		{
			var idInfo = typeof(T).GetTypeInfo().GetProperty("Id");
			if (idInfo == null)
			{
				throw new ArgumentException("参数没有基于约定将主键的属性名设置为Id");
			}
			var insModel = Activator.CreateInstance(typeof(T));
			idInfo.SetValue(insModel, id);
			var models = await GetAsync((T)insModel);
			return models.SingleOrDefault();
		}

		/// <summary>
		/// 添加一条数据
		/// </summary>
		/// <param name="model"></param>
		/// <returns>添加数据的Id</returns>
		public Task<int> InsertAsync(T model)
		{
			var assignedPropertyKeys = model.GetAssignedProperties().Select(m => m.Key).ToList();
			string sql = $@"
				INSERT INTO {_tableName}
					({string.Join(",", assignedPropertyKeys)})
				VALUES
					(@{string.Join(",@", assignedPropertyKeys)});
				SELECT @@IDENTITY;";
			return _db.QueryFirstAsync<int>(sql, model);
		}

		public Task<int> UpdateAsync(T model, T where)
		{
			var assignedProperty = model.GetAssignedProperties().ToList();
			var assignedPropertyKeys = assignedProperty.Select(m => m.Key).ToList();
			var assignedPropertyFromWhere = where.GetAssignedProperties().ToList();
			var assignedPropertyKeysFromWhere = assignedPropertyFromWhere.Select(m => m.Key).ToList();

			string sql = $@"
				UPDATE {_tableName}
				SET {_tempDelegate(assignedPropertyKeys, null)}
				WHERE {_tempDelegate(assignedPropertyKeysFromWhere, "2")}";
			int count;
			using (var cmd = _db.CreateCommand())
			{
				cmd.CommandText = sql;
				foreach (var item in assignedProperty)
				{
					cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
				}
				foreach (var item in assignedPropertyFromWhere)
				{
					cmd.Parameters.Add(new SqlParameter(item.Key + 2, item.Value));
				}
				_db.Open();
				count = Convert.ToInt32(cmd.ExecuteNonQuery());
				_db.Close();
			}
			return Task.FromResult(count);
		}

		public Task<int> UpdateAsync(T model)
		{
			var id = model.GetType().GetTypeInfo().GetProperty("Id");
			if (id == null)
			{
				throw new ArgumentException("参数没有基于约定将主键的属性名设置为Id");
			}
			var value = id.GetValue(model);
			if (Convert.ToInt32(value) <= 0)
			{
				throw new ArgumentException("参数没有指定Id的值");
			}
			id.SetValue(model, 0);
			var where = Activator.CreateInstance(typeof(T));
			id.SetValue(where, value);
			return UpdateAsync(model, (T)where);
		}

		public Task<int> DeleteAsync(T model)
		{
			var assignedPropertyKeys = model.GetAssignedProperties().Select(m => m.Key);
			string sql = $@"DELETE FROM dbo.TblArticle WHERE {_tempDelegate(assignedPropertyKeys, null)}";
			return _db.ExecuteAsync(sql, model);
		}
	}
}
