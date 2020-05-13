using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blogs.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Blog",
                url: "{blog}",
                defaults: new { controller = "Blog", action = "Index" },
                constraints: new {blog="\\w+" }
                );

            routes.MapRoute(
           name: "BlogArticle",
           url: "{blog}/p/{id}.html",
           defaults: new { controller = "Blog", action = "Article" },
           constraints: new { id= "\\d+"}
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Blogs.Web.Controllers" }
            );
        }
    }
}
