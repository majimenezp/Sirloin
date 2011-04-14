using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sirloin.Routing;

namespace Sirloin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                "PageEditor", // Route name
                "Editor/{action}/{id}", // URL with parameters
                new { controller = "Editor", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "MenuEditor", // Route name
                "Menu/{action}/{id}", // URL with parameters
                new { controller = "Menu", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "ControlPanel", // Route name
                "ControlPanel/{action}/{id}", // URL with parameters
                new { controller = "ControlPanel", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
               "Media", // Route name
               "Media/{action}/{id}", // URL with parameters
               new { controller = "Media", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );

            routes.MapRoute("Pages", "{pageid}", new { Controller = "Page", Action = "Show", pageid = UrlParameter.Optional });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}