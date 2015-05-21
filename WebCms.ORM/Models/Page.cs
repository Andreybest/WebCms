using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class Page
    {
        public Page()
        {
           // this.Articles = new List<Article>();
           // this.StyleCsses = new List<StyleCss>();
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public int? PageOrder { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<StyleCss> StyleCsses { get; set; }
    }
}
