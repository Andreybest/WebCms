using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class StyleCss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
