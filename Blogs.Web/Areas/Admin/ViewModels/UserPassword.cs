using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Areas.Admin.ViewModels
{
    public class UserPassword
    {      

        [StringLength(20)]
        [Required]
        [Display(Name = "原密码")]
        public string Pwd { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "新密码")]
        public string NewPwd { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "确认密码")]
        [Compare("NewPwd",ErrorMessage ="{0}和新密码{1}不一致")]
        public string ComfirmPwd { get; set; }

    }
}