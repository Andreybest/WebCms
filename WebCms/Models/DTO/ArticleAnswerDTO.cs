using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCms.ORM.Models;

namespace WebCms.Models.DTO
{
    public class ArticleAnswerDTO
    {
        public ArticleAnswerDTO(ArticleAnswer articleAnswer)
        {
            ArticleId = articleAnswer.ArticleId;
            AnswerText = articleAnswer.AnswerText;
            AnswerType = articleAnswer.AnswerType;
            IsApproved = articleAnswer.IsApproved;
        }

        public int ArticleId { get; set; }
        public string AnswerText { get; set; }
        public int? AnswerType { get; set; }
        public bool? IsApproved { get; set; }

    }
}