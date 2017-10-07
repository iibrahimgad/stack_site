using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stack.DBContext.Entities
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ArName { get; set; }
        public string ImgSrc { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}