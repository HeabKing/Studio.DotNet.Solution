using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Domain
{
	public class TblUserTblArticle
	{
		public int Id { get; set; }
		public int AuthorId { get; set; }
		public int ArticleId { get; set; }
		public System.DateTime CreateTime { get; set; }
		public string Remark { get; set; }
		public bool IsDelete { get; set; }

		public  TblArticle TblArticle { get; set; }
		public  TblUser TblUser { get; set; }
	}
}
