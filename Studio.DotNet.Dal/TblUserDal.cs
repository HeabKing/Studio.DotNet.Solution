using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

// ReSharper disable ClassNeverInstantiated.Global
namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 用户表相关操作
	/// </summary>
	public class TblUserDal : BaseDal<Domain.TblUser>, IDal.ITblUserDal
	{
		public TblUserDal(IDbConnection db) : base(db, nameof(Domain.TblUser))
		{
		}
	}
}
