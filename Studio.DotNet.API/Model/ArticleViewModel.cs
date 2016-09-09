using System.Collections.Generic;

namespace Studio.DotNet.API.Model
{
    public class ArticleViewModel
    {
        public int UserId { get; set; }
        public Domain.TblArticle Article { get; set; }
        public IEnumerable<Domain.TblTag> Tags { get; set; }
    }
}
