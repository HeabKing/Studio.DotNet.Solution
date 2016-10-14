using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Studio.DotNet.Domain;

namespace Studio.DotNet.Dal
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class TblUserTblArticleDal : BaseDal<TblUserTblArticle>, IDal.ITblUserTblArticleDal
	{
		public TblUserTblArticleDal(IDbConnection db, string tableName) : base(db, tableName)
		{
		}
	}
}
