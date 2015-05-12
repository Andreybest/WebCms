using System;
using System.Collections.Generic;

namespace WebCms.ORM.Models
{
    public partial class ArticleAnswer
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string AnswerText { get; set; }
        public Nullable<int> AnswerType { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public virtual Article Article { get; set; }
    }
}
