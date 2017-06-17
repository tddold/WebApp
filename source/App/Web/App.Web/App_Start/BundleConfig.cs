using System.Web;
using System.Web.Optimization;

namespace App.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/assets/js/jquery-1.12.3.min.js"));
                        "~/assets/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/them").Include(
                       "~/assets/js/jquery - 1.11.1.js",
                       "~/assets/js/bootstrap.js",
                       "~/assets/js/jquery.easing.min.js",
                       "~/assets/js/jquery.isotope.js",
                       "~/assets/js/appear.min.js",
                       "~/assets/js/animations.min.js",
                       "~/assets/js/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/themvega").Include(
                     "~/assets/js/vegas/jquery.vegas.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/themfan").Include(
                    "~/assets/js/source/jquery.fancybox.js"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/js/bootstrap.js",
                      "~/assets/js/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapthem").Include(
                     "~/assets/css/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/ionicons").Include(
                     "~/assets/css/ionicons.css"));

            bundles.Add(new ScriptBundle("~/bundles/font-awesome").Include(
                     "~/assets/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/bundles/animations").Include(
                     "~/assets/css/animations.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/blue").Include(
                     "~/assets/css/style-blue.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                  "~/Scripts/KendoUI/kendo.all.min.js",
                  "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

                  bundles.Add(new ScriptBundle("~/bundles/jquerykendo").Include(
                   "~/Scripts/jquery.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/themjq").Include(
                  "~/assets/js/source/jquery.fancybox.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                   "~/Content/KendoUI/kendo.common.min.css",
                   "~/Content/KendoUI/kendo.default.min.css"));
        }
    }
}
