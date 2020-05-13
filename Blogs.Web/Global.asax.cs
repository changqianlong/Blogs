using AutoMapper;
using Blogs.Web.Areas.Admin.ViewModels;
using Blogs.Web.Core;
using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blogs.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var blogcontext = new BlogsContext())
            {
                //������ݿⲻ�����򴴽�
                bool res = blogcontext.Database.CreateIfNotExists();
            }

            //����automap
            Mapper.Initialize(x =>
            {
                x.CreateMap<CatalogAdd, Catalog>();
                x.CreateMap<BlogApply, Blog>();
                x.CreateMap<ArticleAdd, Article>();
            });
                             
        }
    }
}
