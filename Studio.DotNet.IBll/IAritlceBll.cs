using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.DotNet.IBll
{
	public interface IAritlceBll : IBaseBll<Domain.TblArticle>
	{
		Task<int> AddAsync(Domain.TblArticle article, IEnumerable<Domain.TblTag> tags, int userId);
	}
}
