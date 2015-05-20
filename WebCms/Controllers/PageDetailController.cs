using System.Web.Mvc;

namespace WebCms.Controllers
{
    public class PageDetailController : Controller
    {
        // GET: Page
        public ActionResult Index(int id)
        {

            /* 
            var currentEvent = RepositoryEvent.Get(id, _userId, SecurityHelper.AllUserOrganizations, true);
                        if (currentEvent == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                        }
            */


            return View("~/Views/PageDetails/PageDetails.cshtml");

        }
    }
}
