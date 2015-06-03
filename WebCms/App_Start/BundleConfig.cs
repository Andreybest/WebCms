using System.Web.Optimization;
using WebCms.Controllers;
using System.Web.Mvc;

namespace WebCms
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/knockout-3.3.0.min.js",
                      "~/Scripts/knockout.validation.js",
                      "~/Scripts/knockout.mapping-latest.js")
                      );
            bundles.Add(new ScriptBundle("~/bundles/notyNotifications").Include(
                     "~/Scripts/noty/jquery.noty.js",
                      "~/Scripts/noty/layouts/bottomLeft.js",
                      "~/Scripts/noty/layouts/center.js",
                      "~/Scripts/noty/themes/default.js",
                      "~/Scripts/noty/Noty.js"
                      )
                );
           // var homeController = new HomeController();
          // var themeName = homeController.GetTheme();
        /*    ViewBag.AnswerText = "Your answer goes here.";
*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Theme/css").Include(
                "~/Content/darkly.bootstrap.min.css"));
        }
    }
}
