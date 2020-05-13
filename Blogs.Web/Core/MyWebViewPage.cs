using Blogs.Web.Core;
using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Blogs.Web.Core
{
    public abstract class MyWebViewPage <T>: WebViewPage<T>
    {
        public override void Execute()
        {

        }

        protected User LoginUser
        {
            get
            {
                return Session["loginUser"] as User;
            }
        }

        protected Blog LogigBlog
        {
            get
            {
                return Session["loginBlog"] as Blog;
            }
        }

        protected BlogsContext blogsdbContext = new BlogsContext();


    }
}