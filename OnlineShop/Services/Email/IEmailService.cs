namespace OnlineShop.Services.Email
{
    public interface IEmailService
    {
        Task SendProductAvailabilityNotificationAsync(string email, string productName);
    }
}
