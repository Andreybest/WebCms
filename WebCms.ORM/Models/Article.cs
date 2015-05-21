using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class Article
    {
        
        public int Id { get; set; }
        public int Type { get; set; }
        public int PageId { get; set; }
        public int? ArticleOrder { get; set; }
        public string AnswerText { get; set; }
        public bool? IsApproved { get; set; }
        public virtual Page Page { get; set; }
      
    }
}
