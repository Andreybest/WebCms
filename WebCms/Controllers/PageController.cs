using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebCms.Models.DTO;
using WebCms.ORM.Models;

namespace WebCms.Controllers
{
    public class PageController : ApiController
    {

        private WebCmsContext _context = new WebCmsContext();
        // GET: api/Page
        [AllowAnonymous]
        [Authorize(Roles = "Manager,Admin")]
        public List<PageDTO> GetPages()
        {
            var pages = from page in _context.Pages select page;
            var pageDto= new List<PageDTO>();
            foreach (var page in pages)
            {
             pageDto.Add(new PageDTO(page));   
            }
            return pageDto;
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
