using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.SignUp
{
    public class SignUpResponseDto
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
      
        public String PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
