using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCms.Models.DTO;
using WebCms.ORM.Models;

namespace WebCms.ApiControllers
{
    public class ArticleEditApiController : ApiController
    {
        private WebCmsContext _context = new WebCmsContext();
        // GET: api/ArticleEditApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ArticleEditApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ArticleEditApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ArticleEditApi/5
      /*  public void Put(int id, [FromBody]string value)
        {

        }*/
        public void Put([FromBody]ArticleDTO article)
        {
            var art = new Article();

            //HACK because of the ID, put make replace to that entity, if the ID wasn't provided, you must get the specified record from DB and uptade it
           /* foreach (var article in articles.ToList())
            {*/
                art.Id = article.Id;
                art.PageId = article.PageId;
                art.Type = article.Type;
                art.AnswerText = article.AnswerText;
                art.IsApproved = article.IsApproved;

                _context.Entry(art).State = EntityState.Modified;
           /* }*/
            _context.SaveChanges();

        }

        // DELETE: api/ArticleEditApi/5
        public void Delete(int id)
        {
        }
    }
}
