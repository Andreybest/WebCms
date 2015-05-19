using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCms.ORM.Models;

namespace WebCms.Models.DTO
{
    public class PageDTO
    {
        public PageDTO(Page page)
        {
            PageName = page.PageName;
            PageOrder = page.PageOrder;
           // Articles = page.Articles;
        }
        public PageDTO()
        {
            
        }
        public string PageName { get; set; }
        public int? PageOrder { get; set; }
       // public IList<ArticleDTO> Articles { get; set; }
    }
}