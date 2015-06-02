using System.Collections.Generic;
using System.Data.Entity;
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
        public List<PageDTO> GetPages()
        {
            var pages = (from page in _context.Pages select page).OrderBy(e => e.Id);
            var pageDto = new List<PageDTO>();
            foreach (var page in pages)
            {
                pageDto.Add(new PageDTO(page));

            }
            return pageDto;
        }

        // GET: api/PageApi/5
        [AllowAnonymous]
        public IList<Page> GetPage(int id)
        {
            var page = from pag in _context.Pages where pag.Id == id select pag;
            return page.ToList();
        }

        // POST: api/PageApi
        [Authorize(Roles = "Manager,Admin")]
        public void Post([FromBody]PageDTO json)
        {
            var art = new Page
            {
                Id = json.Id,
                PageName = json.PageName,
                PageDescription = json.PageDescription
            };

            _context.Entry(art).State = EntityState.Added;
            _context.SaveChanges();
        }

        // PUT: api/PageApi/5
        [Authorize(Roles = "Manager,Admin")]
        public void Put([FromBody]PageDTO jsonPage)
        {
            var pag = new Page();

            pag.Id = jsonPage.Id;
            pag.PageName = jsonPage.PageName;
            pag.PageDescription = jsonPage.PageDescription;

            _context.Entry(pag).State = EntityState.Modified;
            _context.SaveChanges();

        }

        // DELETE: api/PageApi/5
        [Authorize(Roles = "Manager,Admin")]
        public void Delete([FromBody]PageDTO page)
        {
            //TODO add cascade delete on Arcitle FK table relationship constraint
            if (page.Id == 0) return;
            var pageToDelete = _context.Pages.Single(e => e.Id == page.Id);
            _context.Entry(pageToDelete).State = EntityState.Deleted;

            _context.SaveChanges();
        }
    }
}
