using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Areas.Admin.ViewModels
{ 
    public class BlogApply
    {
       [Required,StringLength(20)]
       [DisplayName("博主昵称")]
        public string NiName { get; set; }

        [Required, StringLength(20)]
        [DisplayName("博客标识符")]
        public string Identity { get; set; }

        [StringLength(100),DisplayName("博客标题")]
        public string Title { get; set; }

        [StringLength(100)]
        [DisplayName("签名")]
        public string Signal { get; set; }

        [StringLength(250),DisplayName("博客描述")]
        public string Description { get; set; }

        [DisplayName("昵称")]
        public int ThemeID { get; set; }
    }
}