using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Email;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmail(string email, int code)
        {
            var textMessage = await _emailService.FillTextMessageAsync("", "1", 1, "Vida");
            await _emailService.SendEmailAsync("test@gmail.com", textMessage);
            return Ok();
        }
    }
}