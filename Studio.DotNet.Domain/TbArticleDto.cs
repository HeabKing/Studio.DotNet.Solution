// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace Studio.DotNet.Domain
{
	/// <summary>
	/// 文章领域模型
	/// </summary>
	/// <remarks>Sinx 2016-08-31</remarks>
    public class TblArticleDto
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ContentUrl { get; set; }
		public System.DateTime CreateTime { get; set; }
		public DateTime UpdateTime { get; set; }
		public bool IsDelete { get; set; }
		public int LikeCount { get; set; }
		public int DislikeCount { get; set; }
	}
}
