using System.Web;
using System.Web.Optimization;

namespace Wunderlist.Web
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
                "~/Scripts/angular_lib/angular-route.min.js"
                ));

            bundles.Add(new ScriptBundle("~/script/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/script/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                   "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/register").Include(
                     "~/Content/register/register.css"));

            bundles.Add(new StyleBundle("~/css/register").Include(
                  "~/Content/login/login.css"));
        }
    }
}
