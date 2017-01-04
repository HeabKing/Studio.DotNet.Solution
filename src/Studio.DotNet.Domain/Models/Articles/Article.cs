using System;
using System.ComponentModel.DataAnnotations;
using Sinx.Infrastructure.DomainBase;

namespace Studio.DotNet.Domain.Models.Articles
{
	/// <summary>
	/// 领域模型
	/// </summary>
    public class Article : EntityBase
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "请输入合法的文章标题")]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		[RegularExpression(@"^/article/html/\d+/\d+\.html", ErrorMessage = "文章地址无效")]
		public string ContentUrl { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime UpdateTime { get; set; }
		public bool IsDelete { get; set; }
		public int LikeCount { get; set; }
		public int DislikeCount { get; set; }
	}
}
