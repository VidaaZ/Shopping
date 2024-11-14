using Microsoft.AspNetCore.Mvc;
using OnlineShop.entities;
using OnlineShop.Models.SignUp;
using OnlineShop.Services.SignUp_UserInformation;

namespace OnlineShop.Controllers
{
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _signUpService;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(ISignUpService signUpService, ILogger<SignUpController> logger)
        {
            _signUpService = signUpService;
            _logger = logger;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignUpRequestDto signUpInfo)
        {
            try
            {
               var result= await _signUpService.SignUpAsync(signUpInfo);
                return Ok(result);
            }
            catch
            {
                return BadRequest("User already exists.");
            }
        }
    }
}
