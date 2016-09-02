// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;
using System.ComponentModel.DataAnnotations;

namespace Studio.DotNet.Domain
{
	/// <summary>
	/// 文章领域模型
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
	public class TblArticle
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		[RegularExpression("^/article/html", ErrorMessage = "不是有效的文章地址")]
		public string ContentUrl { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime UpdateTime { get; set; }
		public bool IsDelete { get; set; }
		public int LikeCount { get; set; }
		public int DislikeCount { get; set; }
	}
}
