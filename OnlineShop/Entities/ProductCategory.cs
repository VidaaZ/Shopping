using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        // Navigation Property for related products
        public ICollection<Product> Products { get; set; }


    }
}
