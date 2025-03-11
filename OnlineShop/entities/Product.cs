using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
      
        public bool IsActive { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }

    }
}
