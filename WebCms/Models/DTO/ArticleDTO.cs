using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCms.Models.DTO
{
    public class ArticleDTO
    {
        public int Type { get; set; }
        public int PageId { get; set; }
        public int  ArticleOrder { get; set; }
        public List<ArticleAnswerDTO> ArticleAnswers { get; set; }
    }
}