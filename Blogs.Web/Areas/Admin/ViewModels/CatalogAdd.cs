﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogs.Web.Areas.Admin.ViewModels
{
    public class CatalogAdd
    {
        [Required,StringLength(20),DisplayName("名称")]
        public string Name { get; set; }

    }
}