using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace canteen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "themgiohang",
                url: "{controller}/{action}", 
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces :new[] { "canteen.Controllers" }
                );
            routes.MapRoute(
               name: "cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "IndexCart", id = UrlParameter.Optional },
               namespaces: new[] { "canteen.Controllers" }
               );
            routes.MapRoute(
               name: "Payment Success",
               url: "hoan-thành",
               defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
               namespaces: new[] { "canteen.Controllers" }
               );
        }
    }
}
