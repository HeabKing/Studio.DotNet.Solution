using System.Data;
// ReSharper disable ClassNeverInstantiated.Global
namespace Studio.DotNet.Dal
{
	/// <summary>
	/// 文章数据访问层
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
	public class TblArticleDal : BaseDal<Domain.TblArticle>, IDal.ITblArticleDal
	{
		public TblArticleDal(IDbConnection db) : base(db, nameof(Domain.TblArticle)){}
	}
}
