using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ProductCategory
{
    public class ProductCategoryRequestDto
    {
        [Required(ErrorMessage = "Name must be filled")]
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
