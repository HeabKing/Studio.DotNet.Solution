using System.Data;
namespace Studio.DotNet.Dal
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class TblArticleTblTagDal : BaseDal<Domain.TblArticleTblTag>, IDal.ITblArticleTblTagDal
	{
		public TblArticleTblTagDal(IDbConnection db) : base(db, nameof(Domain.TblArticleTblTag))
		{
		}
	}
}
