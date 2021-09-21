using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class TbBlogImages
    {
        public int TbBlogImagesId { get; set; }
        public string  Image { get; set; }
        public int BlogId { get; set; } 
        public virtual TbBlog Blog { get; set; }
    }
}
