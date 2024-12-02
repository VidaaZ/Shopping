using Microsoft.AspNetCore.Mvc;
using OnlineShop.entities;
using OnlineShop.Models.Login;
using OnlineShop.Models.SignUp;
using OnlineShop.Services.SignUp_UserInformation;

namespace OnlineShop.Controllers
{
    
    [Route("api/signup")]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _signUpService;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(ISignUpService signUpService, ILogger<SignUpController> logger)
        {
            _signUpService = signUpService;
            _logger = logger;
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] SignUpRequestDto signUpInfo)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signUpService.SignUpAsync(signUpInfo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequest)
        {
            try
            {
                var isAuthenticated = await _signUpService.LoginAsync(loginRequest.UserName, loginRequest.Password);

                if (!isAuthenticated)
                    return Unauthorized("Invalid username or password");

                return Ok("Login successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}