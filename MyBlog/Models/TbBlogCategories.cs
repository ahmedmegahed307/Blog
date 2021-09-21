using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class TbBlogCategories
    {
        public int TbBlogCategoriesId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
        public virtual ICollection<TbBlog> Blog { get; set; }
    } 
}
