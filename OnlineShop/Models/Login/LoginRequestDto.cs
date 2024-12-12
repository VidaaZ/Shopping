﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Login
{
   


public class LoginRequestDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

}
