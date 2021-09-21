using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.InterfaceClasses
{
    public interface IBlogService
    {
        List<TbBlog> GetAllBlogs();
        TbBlog GetBlogById(int id );
        bool AddBlog(TbBlog blog);
        bool EditBlog(TbBlog blog);
        bool Delete(int id);

    }
    public class ClsBlog : IBlogService
    {
        BlogContext ctx;
        public ClsBlog(BlogContext context)
        {
            ctx = context;
        }

      
        public List<TbBlog> GetAllBlogs()
        {
            return ctx.TbBlog.Include(a=>a.Category).ToList();
            
        }
        public TbBlog GetBlogById(int id)
        {
            var blog = ctx.TbBlog.Where(a => a.TbBlogId == id).FirstOrDefault();
            return blog;
        }
        public bool AddBlog(TbBlog blog)
        {

            ctx.TbBlog.Add(blog);
            ctx.SaveChanges();
            return true;

        }
        public bool EditBlog(TbBlog blog)
        {
            ctx.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var result = ctx.TbBlog.Where(a => a.TbBlogId == id).FirstOrDefault();
            ctx.TbBlog.Remove(result);
            ctx.SaveChanges();
            return true;
        }

    }
}
