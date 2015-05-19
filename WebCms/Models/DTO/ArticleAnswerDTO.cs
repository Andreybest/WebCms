using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCms.Models.DTO
{
    public class ArticleAnswerDTO
    {
        public int ArticleId { get; set; }
        public string AnswerText { get; set; }
        public int AnswerType { get; set; }

    }
}