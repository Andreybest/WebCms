using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class Article
    {
        public Article()
        {
            this.ArticleAnswers = new List<ArticleAnswer>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int PageId { get; set; }
        public Nullable<int> ArticleOrder { get; set; }
        public virtual Page Page { get; set; }
        public virtual IList<ArticleAnswer> ArticleAnswers { get; set; }
    }
}
