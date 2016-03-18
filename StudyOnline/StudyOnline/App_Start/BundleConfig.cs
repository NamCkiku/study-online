using System.Web;
using System.Web.Optimization;

namespace StudyOnline
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Contents/js/jquery-1.11.1.min.js",
                      "~/Contents/js/modernizr.custom.min.js",
                      "~/Contents/js/jquery.magnific-popup.js",
                      "~/Contents/js/responsiveslides.min.js",
                      "~/Scripts/angular.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Contents/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Contents/css").Include(
                      "~/Contents/css/bootstrap.min.css",
                         "~/Contents/css/dashboard.css",
                          "~/Contents/css/style.css",
                         "~/Contents/css/popuo-box.css",
                           "~/Contents/fonts/font-awesome/css/font-awesome.css",
                      "~/Contents/site.css"));

            
        }
    }
}
