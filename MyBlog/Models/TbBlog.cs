using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class TbBlog
    {
        public int TbBlogId { get; set; }
        [Required,MaxLength(50)]
        public string BlogTitle { get; set; }
        [Required, MaxLength(200)]
        public string BlogContent { get; set; }
        [Required]
        public string BlogImage { get; set; }
        public string CategoryId { get; set; }//Foreign Key
        public virtual TbBlogCategories Category { get; set; }
        public virtual ICollection<TbBlogComments> TbBlogComments { get; set; }
        public virtual ICollection<TbBlogImages> TbBlogImages { get; set; }


    }
}
