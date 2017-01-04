using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.Domain.Models.Articles
{
	/// <summary>
	/// 文章资源库接口
	/// </summary>
	/// <remarks>
	/// 值得注意的是, 资源库的实现可能会非常像是基础设施, 但是资源库的接口确实纯粹的领域模型 (DDD Simple P31)
	/// </remarks>
    public interface IArticleRepository
    {
    }
}
