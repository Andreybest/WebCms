using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebCms.Models.DTO;
using WebCms.ORM.Models;

namespace WebCms.ApiControllers
{
    public class ArticleApiController : ApiController
    {
        private WebCmsContext _context = new WebCmsContext();
        // GET: api/ArticleApi
        public List<Article> Get()
        {
            var articles = from article in _context.Articles select article;
            return articles.ToList();
        }

        // GET: api/Article/5
        [HttpGet]
        public List<ArticleDTO> Get(int id)
        {
            var articles = _context.Articles.Where(e => e.PageId == id).OrderBy(e => e.Id);
            var artDto = new List<ArticleDTO>();
            foreach (var article in articles)
            {
                artDto.Add(new ArticleDTO(article));

            }

            return artDto;
        }

        // POST: api/Article
        public void Post([FromBody]string value)
        {
        }


        // PUT: api/Article/5
        public void Put(int id, [FromBody]List<ArticleDTO> articles)
        {
            Article art = new Article();

            foreach (var json in articles)
            {
                art.PageId = json.PageId;
                art.Type = json.Type;
                art.AnswerText = json.AnswerText;
                art.IsApproved = json.IsApproved;

                _context.Entry(art).State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
