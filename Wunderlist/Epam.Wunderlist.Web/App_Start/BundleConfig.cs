using System.Web.Optimization;

namespace Epam.Wunderlist.Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/script/jqueryval").Include(
                        "~/Scripts/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/script/angular").Include(
                "~/Scripts/angular_lib/angular.min.js",
                "~/Scripts/angular_lib/angular-route.min.js",
                "~/Scripts/angular_lib/angular-resource.min.js",
                "~/Scripts/angular_lib/angularModalService.js",
                 "~/Scripts/angular-ui/ui-bootstrap.min.js"
                ));

            bundles.Add(new ScriptBundle("~/script/webapp").Include(
                "~/Scripts/app/app.js"
                )
                .IncludeDirectory("~/Scripts/app/controllers", "*.js")
                .IncludeDirectory("~/Scripts/app/services", "*.js"));

            bundles.Add(new ScriptBundle("~/script/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/script/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                   "~/Content/bootstrap.min.css",
                   "~/Content/ui-bootstrap-csp.css"));

            bundles.Add(new StyleBundle("~/css/webapp").Include(
                      "~/Content/webapp.css",
                      "~/Content/webapp-media.css",
                        "~/Content/userModal.css"));

            bundles.Add(new StyleBundle("~/css/account").Include(
                     "~/Content/account.css"));

        }
    }
}
