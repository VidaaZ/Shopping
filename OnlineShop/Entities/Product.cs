using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        // Navigation Property
        public ProductCategory ProductCategory { get; set; }
    }
}
//Product and Product Category has a one-to-many relationship.