using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Product
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Name must be filled")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price must be filled")]
        public string Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please enter Category Id")]
        public int CategoryId { get; set; }
        // Navigation Property
        
    }
}
