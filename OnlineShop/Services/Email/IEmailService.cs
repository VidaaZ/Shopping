using OnlineShop.Models.Email;

namespace OnlineShop.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequestDto emailRequest);
    }
}
