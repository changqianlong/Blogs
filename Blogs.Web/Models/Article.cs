using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Models
{
    public class Article
    {
        public int ID { get; set; }

        public int CatalogID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>     
        public int UP { get; set; }

        public int Views { get; set; }

        public int UserID { get; set; }

        public int BlogID { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool Status { get; set; }

        /// <summary>
        /// 是否显示在首页
        /// </summary>
        public bool IsShowHome { get; set; }

    }
}