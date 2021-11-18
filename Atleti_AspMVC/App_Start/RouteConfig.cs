using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Atleti_AspMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapMvcAttributeRoutes(); //abilita la sintassi di attribute routing nelle varie classi come controllers

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //local host: pippo / pluto -> pippo controller -- pluto -> action
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
