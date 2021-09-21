using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.InterfaceClasses
{
    public interface ICategoryService
    {
        List<TbBlogCategories> GetAllCategories();
        TbBlogCategories GetCategoryById(int id);
        bool addcategory(TbBlogCategories category);
        bool editcategory(TbBlogCategories category);
        bool Delete(string name);
    }
    public class ClsCategory:ICategoryService
    {
        BlogContext ctx;
        public ClsCategory(BlogContext context)
        {
            ctx = context;
        }

        public List<TbBlogCategories> GetAllCategories()
        {
            return ctx.TbBlogCategories.ToList();
        }

        public TbBlogCategories GetCategoryById(int id)
        {
            var blog = ctx.TbBlogCategories.Where(a => a.TbBlogCategoriesId == id).FirstOrDefault();
            return blog;
        }
        public bool addcategory(TbBlogCategories category)
        {
            ctx.TbBlogCategories.Add(category);
            ctx.SaveChanges();
            return true;
        }
        public bool editcategory(TbBlogCategories category)
        {
            ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ctx.SaveChanges();
            return true;
        }
        public bool Delete(string name)
        {
            var result = ctx.TbBlogCategories.Where(a => a.CategoryName == name).FirstOrDefault();
            ctx.TbBlogCategories.Remove(result);
            ctx.SaveChanges();
            return true;
        }

    }
}
