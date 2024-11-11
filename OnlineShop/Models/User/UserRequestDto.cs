
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.User
{
    public class UserRequestDto
    { 
        [Required(ErrorMessage ="Name must be filled")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Family must be filled")]
        public string Family { get; set; }

        [Required(ErrorMessage = "Email must be filled")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username must be filled")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be filled")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password must be filled")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Please Enter Role")]
        public int RoleId { get; set; }
    }
}
