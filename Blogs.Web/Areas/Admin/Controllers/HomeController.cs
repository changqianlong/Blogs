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
    public class HomeController : AdminBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(BlogApply info)
        {
            if(ModelState.IsValid)
            {                           
                var model = Mapper.Map<Blog>(info);
                model.AddTime = DateTime.Now;
                model.EditTime = DateTime.Now;
                model.Status = true;
                model.UserID = LoginUser.ID;
                blogsdbContext.blog.Add(model);
                int res = blogsdbContext.SaveChanges();
                //TODO:把这里以后放到事务里面

                if( res > 0)
                {
                    LoginUser.BlogID = model.ID;
                    blogsdbContext.user.Attach(LoginUser);
                    blogsdbContext.Entry<User>(LoginUser).State = System.Data.Entity.EntityState.Modified;

                    Session["LoginBlog"] = model;
                    res = blogsdbContext.SaveChanges();                    
                    return Content("申请成功");
                }
            }
            return View();
        }

       
    }
}