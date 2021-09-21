
using MyBlog.InterfaceClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    
    public class CategoryController : Controller
    {
        ICategoryService ICategory;
        public CategoryController(ICategoryService qq)
        {
            ICategory = qq;
        }

        public IActionResult CategoryList()
        {
            return View(ICategory.GetAllCategories());
        }

        public IActionResult CategoryEdit(int? id)
        {
            if (id != null)
            {
                return View(ICategory.GetCategoryById(Convert.ToInt32(id)));

            }
            else

                return View();
        }
      
        [HttpPost]
        public IActionResult Save(TbBlogCategories category)
        {

            if (category.TbBlogCategoriesId ==0)
            {
                ICategory.addcategory(category);

            }
            else
            {
                ICategory.editcategory(category);
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult Delete(string name)
        {
            ICategory.Delete(name);
            return RedirectToAction("CategoryList");
            
        }
    }
}
