using System.ComponentModel.DataAnnotations;

namespace OnlineShop.entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public int RoleId { get; set; }        
        public OnlineShop.entities.Role Role { get; set; }
    }
}
