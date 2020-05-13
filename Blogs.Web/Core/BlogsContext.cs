using Blogs.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blogs.Web.Core
{
    public class BlogsContext : DbContext
    {
        public BlogsContext() : base("name=conn")
        {

        }

        public DbSet<Admin> admin {get;set;}
        public DbSet<User> user { get; set; }
        public DbSet<Blog> blog { get; set; }
        public DbSet<Catalog> catalog { get; set; }
        public DbSet<Article> article { get; set; }
        
    }
}