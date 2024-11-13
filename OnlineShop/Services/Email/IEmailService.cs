namespace OnlineShop.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string textMessage);
        Task<string> FillTextMessageAsync(string textMessage, string code, int number, string firstName);
        
    }
}
