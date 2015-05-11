using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class Page
    {
        public Page()
        {
            this.Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public Nullable<int> PageOrder { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
