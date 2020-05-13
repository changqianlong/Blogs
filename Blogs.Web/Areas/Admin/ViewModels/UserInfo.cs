using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Areas.Admin.ViewModels
{
    public class UserInfo
    {
       
        
        [StringLength(30)]
        [Required]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        
    }
}