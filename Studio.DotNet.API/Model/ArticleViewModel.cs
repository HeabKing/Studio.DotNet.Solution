using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Studio.DotNet.API.Model
{
	// ReSharper disable UnusedAutoPropertyAccessor.Global
	public class ArticleViewModel : Domain.TblArticle
	{
		[Required(ErrorMessage = "Can't get UserId from article creation")]
		[Range(1, 1000000, ErrorMessage = "文章作者错误")]
		public int UserId { get; set; }
		[Required(ErrorMessage = "请输入文章标签")]
		public string Tags { get; set; }
	}
}
