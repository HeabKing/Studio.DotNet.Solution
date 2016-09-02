using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Domain
{
	public partial class TblArticleTblTag
	{
		public int Id { get; set; }
		public int ArticleId { get; set; }
		public int TagId { get; set; }
		public DateTime CreateTime { get; set; }
		public bool IsDelete { get; set; }

		public virtual TblArticle TblArticle { get; set; }
		public virtual TblTag TblTag { get; set; }
	}
}
