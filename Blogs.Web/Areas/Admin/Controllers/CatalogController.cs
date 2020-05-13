using AutoMapper;
using Blogs.Web.Areas.Admin.ViewModels;
using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Areas.Admin.Controllers
{
    public class CatalogController : AdminBaseController
    {
        // GET: Admin/Catalog
        public ActionResult Index()
        {
            var list = blogsdbContext.catalog.ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CatalogAdd info)
        {

            if(ModelState.IsValid)
            {
               // Mapper.Initialize(x => x.CreateMap<CatalogAdd, Catalog>());
                var model = Mapper.Map<Catalog>(info);
                model.AddTime = DateTime.Now;
                model.EditTime = DateTime.Now;
                model.BlogID = LoginBlog.ID;
                model.Status = true;
                blogsdbContext.catalog.Add(model);
                int res =  blogsdbContext.SaveChanges();
                if(res > 0 )
                {
                    return RedirectToAction("Index");
                }
            }

            return View(info);
        }
    }
}