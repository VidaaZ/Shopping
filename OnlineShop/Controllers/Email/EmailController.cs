using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.Email;
using OnlineShop.Services.Email;

namespace OnlineShop.Controllers.Email
{
    [ApiController]
    [Route("api/send-email")]
    public class EmailController : ControllerBase
    {
        #region Properties

        private readonly IEmailService _emailService;

        #endregion

        #region Constructor
        
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send([FromForm] EmailRequestDto emailRequestDto)
        {
            try
            {
                await _emailService.SendEmailAsync(emailRequestDto);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
