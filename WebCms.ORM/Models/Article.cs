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
        public string Type { get; set; }
        public int PageId { get; set; }
        public Nullable<int> ArticleOrder { get; set; }
        public virtual Page Page { get; set; }
        public virtual ICollection<ArticleAnswer> ArticleAnswers { get; set; }
    }
}
