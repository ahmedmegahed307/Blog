using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.InterfaceClasses;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        IBlogService BlogService;
        ICategoryService CategoryService;
        BlogContext ctx;
        public BlogController(IBlogService interfaces, ICategoryService interfaces2, BlogContext context)
        {
            BlogService = interfaces;
            CategoryService = interfaces2;
            ctx = context;

        }
        public IActionResult BlogList()
        {
            return View(BlogService.GetAllBlogs());
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.cat = CategoryService.GetAllCategories();///drop down list
            if (id != null)
            {


                return View(BlogService.GetBlogById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Save(TbBlog blog, List<IFormFile> Files)
        {

            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\BlogsPhoto", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    blog.BlogImage = ImageName;
                }
            }

            if (blog.TbBlogId == 0)
            {
                BlogService.AddBlog(blog);

            }
            else
            {
                BlogService.EditBlog(blog);
            }
            return RedirectToAction("BlogList");

        }
        public IActionResult Delete(int id)
        {
            BlogService.Delete(id);
            return RedirectToAction("BlogList");
        }
        public IActionResult ShowBlog()
        {

            return View(ctx.TbBlog.ToList());
        }

      
    }
}
