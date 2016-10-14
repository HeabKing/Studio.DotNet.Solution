using System.Data;
// ReSharper disable once ClassNeverInstantiated.Global
namespace Studio.DotNet.Dal
{
	public class TblTagDal : BaseDal<Domain.TblTag>, IDal.ITblTagDal
	{
		public TblTagDal(IDbConnection db, string tableName) : base(db, tableName)
		{
		}
	}
}
