using System.Web;
using System.Web.Optimization;

namespace StudyOnline
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/angular.js",
                        "~/Angularjs/Users/UserController.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Contents/js").Include(
                   "~/Scripts/angular.js",
                        "~/Contents/js/jquery.js",
                        "~/Contents/js/bootstrap.min.js",
                        "~/Contents/js/jquery.dcjqaccordion.2.7.js",
                        "~/Contents/js/jquery.scrollTo.min.js",
                        "~/Contents/js/jquery.nicescroll.js",
                        "~/Contents/js/respond.min.js",
                        "~/Contents/js/slidebars.min.js",
                        "~/Contents/js/common-scripts.js",
                           "~/App_Scripts/Module.js",
                        "~/App_Scripts/Service.js",
                        "~/App_Scripts/Controller.js"
                        ));
            bundles.Add(new StyleBundle("~/Contents/css").Include(
                          "~/Contents/css/bootstrap.min.css",
                          "~/Contents/css/bootstrap-reset.css",
                          "~/Contents/fonts/font-awesome/css/font-awesome.css",
                          "~/Contents/css/slidebars.css",
                          "~/Contents/css/ListCourse.css",
                          "~/Contents/css/style.css",
                          "~/Contents/css/style-responsive.css"
                      ));
            bundles.Add(new StyleBundle("~/Contents/homeindex").Include(
                          "~/Contents/HomeIndex/css/bootstrap.min.css",
                          "~/Contents/HomeIndex/css/custom.css",
                          "~/Contents/fonts/font-awesome/css/font-awesome.css",
                          "~/Contents/HomeIndex/css/flexslider.css",
                          "~/Contents/css/ListCourse.css",
                          "~/Contents/css/style.css",
                          "~/Contents/css/style-responsive.css"
                      ));
        }
    }
}
