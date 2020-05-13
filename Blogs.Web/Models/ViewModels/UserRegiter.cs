using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Models
{
    public class UserRegiter
    {
        //password
       

        [Required]
        [StringLength(20)]
        [Display(Name="用户名")]
        public string Name { get; set; }

        
        [StringLength(30)]
        [Required]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
              
        [StringLength(20)]
        [Required]
        [Display(Name = "密码")]
        public string Pwd { get; set; }

        [StringLength(10)]
        [Required]
        [Display(Name = "验证码")]
        public string VelidateCode { get; set; }
    }
}