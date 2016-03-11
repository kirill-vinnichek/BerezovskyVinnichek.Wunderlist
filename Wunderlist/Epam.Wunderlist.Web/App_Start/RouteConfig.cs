using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.Wunderlist.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Home/WebApp");
            routes.MapRoute(
                name: "WebApp",
                url: "webapp",
                defaults: new { controller = "Home", action = "WebApp" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
