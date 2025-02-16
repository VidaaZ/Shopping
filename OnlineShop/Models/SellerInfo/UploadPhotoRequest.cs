using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.SellerInfo
{
    public class UploadPhotoRequest
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
