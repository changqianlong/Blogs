using AutoMapper;
using Blogs.Web.Areas.Admin.ViewModels;
using Blogs.Web.Core;
using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Areas.Admin.Controllers
{
    public class ArticleController : AdminBaseController
    {
       
        public ActionResult Index()
        {
            ViewBag.CatalogList = blogsdbContext.catalog.ToList();
            var listArtilce = blogsdbContext.article.ToList();
            return View(listArtilce);
        }

        public ActionResult Add()
        {
            ViewBag.CatalogList = blogsdbContext.catalog.ToList();           
            return View();
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult Add(ArticleAdd info)
        {

            if(ModelState.IsValid)
            {
                var model = Mapper.Map<Article>(info);
                model.AddTime = DateTime.Now;
                model.EditTime = DateTime.Now;
                model.BlogID = LoginBlog.ID;
                model.IsShowHome = true;
                model.Status = true;
                model.UserID = LoginUser.ID;
                model.UP = 0;
                model.Views = 0;
                model.Description = StringHelper.ReplaceHtmlTag(model.Content,150);

                blogsdbContext.article.Add(model);

                var res =  blogsdbContext.SaveChanges();
                if(res > 0)
                {
                    return Redirect(string.Format("/{0}/p/{1}.html",LoginBlog.Identity,model.ID));
                }
            }

            return View(info);
        }
    }
}