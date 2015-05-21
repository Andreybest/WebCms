using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCms.ORM.Models;

namespace WebCms.Models.DTO
{
    public class ArticleDTO
    {
        public ArticleDTO(Article article)
        {
            Id = article.Id;
            Type = article.Type;
            PageId = article.PageId;
            ArticleOrder = article.ArticleOrder;
            AnswerText = article.AnswerText;
            IsApproved = article.IsApproved;

        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int PageId { get; set; }
        public int?  ArticleOrder { get; set; }
        public string AnswerText { get; set; }
        public bool? IsApproved { get; set; }
    }
}