using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebCms.ORM.Models;

namespace WebCms.ApiControllers
{
    public class ArticleApiController : ApiController
    {
        private WebCmsContext _context = new WebCmsContext();
        // GET: api/ArticleApi
        public List<Article> Get()
        {
            var articles = (from article in _context.Articles select article).OrderBy(e => e.ArticleOrder).Where(e => e.PageId==1);
           /* var articleDto = new List<ArticleDTO>();
            foreach (var article in articles.ToList())
            {
                articleDto.Add(new ArticleDTO(article));

            }
            return articleDto.ToList();*/
            return articles.ToList();
        }

        // GET: api/Article/5
        public List<Article> Get(int id)
        {
            var articles = (from article in _context.Articles select article).OrderBy(e => e.ArticleOrder).Where(e => e.PageId == id);
            /* var articleDto = new List<ArticleDTO>();
             foreach (var article in articles.ToList())
             {
                 articleDto.Add(new ArticleDTO(article));

             }
             return articleDto.ToList();*/
            return articles.ToList();
        }

        // POST: api/Article
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Article/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
