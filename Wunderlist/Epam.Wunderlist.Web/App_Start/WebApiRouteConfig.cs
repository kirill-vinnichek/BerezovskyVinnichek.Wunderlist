using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Epam.Wunderlist.Web
{
    public static class WebApiRouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "TaskRoute",
                routeTemplate: "api/itemList/{taskListId}/task/{taskId}",
                defaults: new { controller = "Item", taskId = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}