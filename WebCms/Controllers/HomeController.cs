using System.Web.Mvc;

namespace WebCms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ApproveArticle()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}