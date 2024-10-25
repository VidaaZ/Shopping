using System.ComponentModel.DataAnnotations;

namespace OnlineShop.entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
       [Required]
        public int CategoryId { get; set; }
        
        public ProductCategory ProductCategory { get; set; }
    }
}
