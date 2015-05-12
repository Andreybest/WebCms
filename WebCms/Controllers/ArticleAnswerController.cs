using System.Collections.Generic;
using System.Web.Http;

namespace WebCms.Controllers
{
    public class ArticleAnswerController : ApiController
    {
        // GET: api/ArticleAnswer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ArticleAnswer/5
        public string Get(int id)
        {
            return "value";
        }
       
        // POST: api/ArticleAnswer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ArticleAnswer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ArticleAnswer/5
        public void Delete(int id)
        {
        }
    }
}
