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
        public List<ArticleDTO> Get()
        {
            var articles = (from art in _context.Articles
                            join pag in _context.Pages on art.PageId equals pag.Id
                            where art.IsApproved == null
                            select art).OrderBy(art => art.Id);

            var artDto = new List<ArticleDTO>();
            foreach (var article in articles.ToList())
            {
                artDto.Add(new ArticleDTO(article));
            }
            return artDto;
        }

        // GET: api/Article/5
        [HttpGet]
        public List<ArticleDTO> Get(int id)
        {
            var articles = _context.Articles.Where(e => e.PageId == id).OrderBy(e => e.Id);
            var artDto = new List<ArticleDTO>();
            foreach (var article in articles.ToList())
            {
                artDto.Add(new ArticleDTO(article));

            }

            return artDto;
        }

        // POST: api/Article
       
        [Authorize(Roles = "Admin, Manager")]
        public void ArticlePut([FromBody]List<ArticleDTO> articles)
        {
            var art = new Article();

            foreach (var json in articles)
            {
                //art.Id = json.Id;
                art.PageId = json.PageId;
                art.Type = json.Type;
                art.AnswerText = json.AnswerText;
                art.IsApproved = json.IsApproved;

                _context.Entry(art).State = EntityState.Added;
                _context.SaveChanges();
            }
        }


        // PUT: api/Article/5
        [Authorize(Roles = "Admin")]
        public void Put([FromBody]ArticleDTO articles)
        {
            var art = new Article();

            //HACK because of the ID, put make replace to that entity, if the ID wasn't provided, you must get the specified record from DB and uptade it
            art.Id = articles.Id;
            art.PageId = articles.PageId;
            art.Type = articles.Type;
            art.AnswerText = articles.AnswerText;
            art.IsApproved = articles.IsApproved;

            _context.Entry(art).State = EntityState.Modified;
            _context.SaveChanges();

        }
        [Authorize(Roles = "Admin, Manager")]
        // DELETE: api/Article/5
        public void Delete([FromBody]ArticleDTO article)
        {
            if (article.Id == 0) return;
            var articleToDelete = _context.Articles.Single(e => e.Id == article.Id);
            _context.Entry(articleToDelete).State = EntityState.Deleted;

            _context.SaveChanges();
        }
    }
}
