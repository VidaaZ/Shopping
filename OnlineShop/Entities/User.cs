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
        public string PasswordHash { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int RoleId { get; set; } // Foreign Key

        public Role Role { get; set; } // Navigation Property
    }

}
/* public class User
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
     public string PasswordHash { get; set; }
     [Required]
     public bool IsActive { get; set; }
     [Required]

     public int RoleId { get; set; }
     public Role Role { get; set; }



 }
}
*/