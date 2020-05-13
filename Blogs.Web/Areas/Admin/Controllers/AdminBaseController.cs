using Blogs.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogs.Web.Areas.Admin.Controllers
{
    public class AdminBaseController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if(LoginUser == null )
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
        }
    }
}