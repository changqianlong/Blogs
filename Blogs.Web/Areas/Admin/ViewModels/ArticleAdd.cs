using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Areas.Admin.ViewModels
{
    public class ArticleAdd
    {

        [StringLength(100), DisplayName("栏目")]
        public string CatalogID { get; set; }

        [StringLength(100), DisplayName("博客标题")]
        public string Title { get; set; }

        [ DisplayName("内容")]
        public string Content { get; set; }


    }
}