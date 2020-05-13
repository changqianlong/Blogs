using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Models
{
    public class Catalog
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int BlogID { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool Status { get; set; }

    }
}