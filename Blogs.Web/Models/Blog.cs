using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Models
{
    public class Blog
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NiName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Signal { get; set; }

        [Required, StringLength(20)]
        public string Identity { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// 主题ID（皮肤）
        /// </summary>
        public int ThemeID { get; set; }

        public int UserID { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool Status { get; set; }

    }
}