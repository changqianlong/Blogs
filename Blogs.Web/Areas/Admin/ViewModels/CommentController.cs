using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Areas.Admin.ViewModels
{
    public class CommentController : Controller
    {
        // GET: Admin/Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}