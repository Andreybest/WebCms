using System.Linq;
using System.Web.Mvc;
using WebCms.ORM.Models;

namespace WebCms.Controllers
{
    public class HomeController : Controller
    {

        private static WebCmsContext _context = new WebCmsContext();
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

        [HttpGet]
        public static string GetTheme()
        {
            var themeName = _context.StyleCsses.Select(c => c.Name).FirstOrDefault();
           
            return themeName;
        }

        public static bool HaveArticlesToApprove()
        {
            var haveArticlesToApprove = _context.Articles.Any(a => a.IsApproved == null);
            return haveArticlesToApprove;
        }
    }
}