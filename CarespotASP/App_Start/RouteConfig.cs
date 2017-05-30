using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarespotASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
    name: "Chat",
    url: "Chat",
    defaults: new { controller = "Chat", action = "Index"}
);

            routes.MapRoute(
    name: "Chat/Id",
    url: "Chat/{id}",
    defaults: new { controller = "Chat", action = "ChatScherm", id = UrlParameter.Optional }
);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}