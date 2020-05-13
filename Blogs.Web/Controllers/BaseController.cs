using Blogs.Web.Core;
using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Controllers
{
    public class BaseController : Controller
    {
        protected User LoginUser
        {
            get
            {
                return Session["loginUser"] as User;
            }
        }
        protected Blog LoginBlog
        {
            get
            {
                return Session["loginBlog"] as Blog;
            }
        }

        protected BlogsContext blogsdbContext = new BlogsContext();

    }
}