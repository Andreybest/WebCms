using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebCms.ORM.Models;

namespace WebCms.Controllers
{
    public class PageController : ApiController
    {

        private WebCmsContext _context = new WebCmsContext();
        // GET: api/Page
          [Authorize(Roles = "Manager,Admin")]
        public IEnumerable<Page> GetPages()
        {
            var pages = from page in _context.Pages select page;
            return pages.ToList();
        }

        // GET: api/Page/5
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IList<Page> GetPage(int id)
        {
            var page = from pag in _context.Pages where pag.Id == id select pag;
            return page.ToList();
        }

        // POST: api/Page
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Page/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Page/5
        public void Delete(int id)
        {
        }
    }
}
