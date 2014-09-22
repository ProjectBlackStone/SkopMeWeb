using System.Web;
using System.Web.Optimization;

namespace SkopMe.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

             bundles.Add(new ScriptBundle("~/bundles/jquery/unitybootstrap/jquery").Include(
                        "~/Content/themes/unifybootstrap/assets/plugins/jquery-1.10.2.min.js",
                        "~/Content/themes/unifybootstrap/assets/plugins/jquery-migrate-1.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/unitybootstrap").Include(
                        "~/Content/themes/unifybootstrap/plugins/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/unitybootstrap/plugins").Include(
                        "~/Content/themes/unifybootstrap/assets/plugins/back-to-top.js",
                        "~/Content/themes/unifybootstrap/plugins/flexslider/jquery.flexslider-min.js",
                        "~/Content/themes/unifybootstrap/plugins/parallax-slider/jquery.cslider.js",
                        "~/Content/themes/unifybootstrap/plugins/parallax-slider/modernizr.js",
                        "~/Content/themes/unifybootstrap/plugins/parallax-slider/jquery.cslider.js",
                        "~/Content/themes/unifybootstrap/plugins/js/app.js",
                        "~/Content/themes/unifybootstrap/plugins/js/index.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/IE8").Include(
                       "~/Content/themes/unifybootstrap/assets/plugins/respond.js",
                       "~/Content/themes/unifybootstrap/assets/plugins/html5shiv.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));


            //removed ~/Content/site.css
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/app.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/themes/unifybootstrap").Include
                ("~/Content/themes/unifybootstrap/plugins/bootstrap/css/bootstrap.css",
                "~/Content/themes/unifybootstrap/assets/style.css",
                "~/Content/themes/unifybootstrap/plugins/line-icons/line-icons.css",
                "~/Content/themes/unifybootstrap/plugins/font-awesome/css/font-awesome.css",
                "~/Content/themes/unifybootstrap/plugins/flexslider/flexslider.css",
                "~/Content/themes/unifybootstrap/plugins/parallax-slider/css/parallax-slider.css",
                "~/Content/themes/unifybootstrap/plugins/default.css",
                "~/Content/app.css"
                ));
        }
    }
}