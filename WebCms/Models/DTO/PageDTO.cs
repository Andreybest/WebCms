using WebCms.ORM.Models;

namespace WebCms.Models.DTO
{
    public class PageDTO
    {
        public PageDTO(Page page)
        {
            Id = page.Id;
            PageName = page.PageName;
            PageOrder = page.PageOrder;
           // Articles = page.Articles;
        }
        public PageDTO()
        {
            
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public int? PageOrder { get; set; }
       // public IList<ArticleDTO> Articles { get; set; }
    }
}