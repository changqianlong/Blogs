using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string IP { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Pwd { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime LastLogTime { get; set; }

        public int LoginTimes { get; set; }

        public int BlogID { get; set; }

        public DateTime EditTime { get; set; }

        public bool Status { get; set; }

    }
}