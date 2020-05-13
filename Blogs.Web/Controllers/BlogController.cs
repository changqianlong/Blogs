using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog 某一个人的博客的控制器
        public ActionResult Index(string blog)
        {

            var model = blogsdbContext.blog.Where(m => m.Identity.ToLower() == blog.ToLower()).FirstOrDefault();

            if (model == null)
            {
                return Content("博客不存在");
            }
            ViewBag.ArticleList = blogsdbContext.article.Where(m => m.BlogID == model.ID).OrderByDescending(m=>m.ID).ToList();
            ViewBag.CatalogList = blogsdbContext.catalog.Where(m => m.BlogID == model.ID).OrderByDescending(m => m.ID).ToList();

            return View(model);           
            
        }

        public ActionResult Article(string blog, int id)
        {
          
          
            var blogModel = blogsdbContext.blog.Where(m => m.Identity.ToLower() == blog.ToLower()).FirstOrDefault();
            if(blogModel == null)
            {
                return Content("博文不存在");
            }
            
            var model = blogsdbContext.article.Where(m => m.ID == id).FirstOrDefault();
            if(model == null )
            {
                return Content("博文不存在");
            }
            ViewBag.Article = model;

            ViewBag.CatalogList = blogsdbContext.catalog.Where(m => m.BlogID == model.ID).OrderByDescending(m => m.ID).ToList();
            return View(blogModel);
        }
    }
}