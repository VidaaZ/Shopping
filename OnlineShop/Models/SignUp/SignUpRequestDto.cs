using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.SignUp
{
    public class SignUpRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
