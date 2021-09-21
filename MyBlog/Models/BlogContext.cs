using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TbBlog> TbBlog { get; set; }
        public virtual DbSet<TbBlogCategories> TbBlogCategories { get; set; }
        public virtual DbSet<TbBlogComments> TbBlogComments { get; set; }
        public virtual DbSet<TbBlogImages> TbBlogImages { get; set; }

    }
}
