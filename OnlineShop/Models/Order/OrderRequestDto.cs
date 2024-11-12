using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Order
{
    public class OrderRequestDto
    {
        [Required(ErrorMessage ="Name must be filled")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Family must be filled")]
        public string Family { get; set; }
        [Required(ErrorMessage = "Address  must be filled")]
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set}
        [Required(ErrorMessage = "PostalCode must be filled")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "ProductId must be filled")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "CategoryId must be filled")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "UserId must be filled")]
        public int UserId { get; set; }



    }
}
