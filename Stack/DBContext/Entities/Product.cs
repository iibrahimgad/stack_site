using System.ComponentModel.DataAnnotations;

namespace Stack.DBContext.Entities
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ArName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ArDescription { get; set; }
        public string ImgSrc { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}