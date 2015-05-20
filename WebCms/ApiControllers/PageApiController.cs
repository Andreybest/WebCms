using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebCms.Models.DTO;
using WebCms.ORM.Models;

namespace WebCms.ApiControllers
{
    public class PageApiController : ApiController
    {

        private WebCmsContext _context = new WebCmsContext();
        // GET: api/PageApi
        [AllowAnonymous]
        [Authorize(Roles = "Manager,Admin")]
        public List<PageDTO> GetPages()
        {
            var pages = from page in _context.Pages select page;
            var pageDto = new List<PageDTO>();
            foreach (var page in pages)
            {
                pageDto.Add(new PageDTO(page));

            }
            return pageDto;
        }

        // GET: api/PageApi/5
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IList<Page> GetPage(int id)
        {
            var page = from pag in _context.Pages where pag.Id == id select pag;
            return page.ToList();
        }

        // POST: api/PageApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PageApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PageApi/5
        public void Delete(int id)
        {
        }
    }
}
