using Blogs.Web.Core;
using Blogs.Web.Models;
using BotDetect.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Controllers
{
    public class HomeController : BaseController
    {
      
        public ActionResult Index()
        {
            //读取全站的博客分类
            var key = "index_catalog";
            var list = new List<Catalog>();
            CacheHelper.ReadCache<List<Catalog>>(key);
            if(list == null)
            {
                list = blogsdbContext.catalog.ToList();
                CacheHelper.WriteCache(key, list, 10, false); //十秒的失效期间
            }           
           ViewBag.Catalogs = list;

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegiter info)
        {
           if(ModelState.IsValid)
            {
                var user = new Models.User
                {
                    Name = info.Name,
                    Pwd = info.Pwd,
                    Email = info.Email,
                    IP = "127.0.0.1",
                    AddTime = DateTime.Now,
                    EditTime = DateTime.Now,
                    LoginTimes = 1,
                    BlogID = 0,
                    LastLogTime = DateTime.Now, 
                    Status = true
                };
                blogsdbContext.user.Add(user);
                var  res = blogsdbContext.SaveChanges(); 
                if(res>0)
                {
                    Session["loginUser"] = user;
                    return Redirect("/");
                }
                else
                {
                    return Content("注册失败");
                }
            }

            return View(info);
        }


        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin info)
        {
            //验证码
            MvcCaptcha mvcCaptcha = new MvcCaptcha("ExampleCaptcha");
            string userInput = HttpContext.Request.Form["VelidateCode"];
            string validatingInstanceId = HttpContext.Request.Form[mvcCaptcha.ValidatingInstanceKey];

            if (mvcCaptcha.Validate(userInput, validatingInstanceId))
            {                
                if (ModelState.IsValid)
                {
                    var dbUser = blogsdbContext.user.Where(m => m.Name.ToLower() == info.Name.ToLower()).FirstOrDefault();
                    if (dbUser != null && dbUser.Pwd == info.Pwd)
                    {
                        Session["loginUser"] = dbUser;
                        //把当前用户的博客记录下来
                        var blog = blogsdbContext.blog.Where(m => m.UserID == dbUser.ID && m.Status).FirstOrDefault();
                        if (blog != null)
                        {
                            Session["loginBlog"] = blog;
                            return Redirect("/"+blog.Identity);
                        }
                        else
                        {
                            return Redirect("/");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "账号或者密码错误");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("VelidateCode", "验证码不正确");
            }
            return View(info);
        }

        


    }
}