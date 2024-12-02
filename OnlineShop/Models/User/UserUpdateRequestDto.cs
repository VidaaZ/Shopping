using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.User
{
    public class UserUpdateRequestDto
    {
        public string? Name { get; set; }  // Nullable to allow optional updates
        public string? Family { get; set; }
       
        public string? Email { get; set; }
        [Required(ErrorMessage = "Username must be filled")]
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public int RoleId { get; set; } // Assuming 0 or negative values are not valid role IDs
    }

    //public string Name { get; set; }


    //public string Family { get; set; }


    //public string Email { get; set; }




    //    public string Password { get; set; }


    //    public string ConfirmPassword { get; set; }


    //    public int RoleId { get; set; }
    //}
}
