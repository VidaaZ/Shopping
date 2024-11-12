using MailKit.Net.Smtp;
using MimeKit;
using OnlineShop.Services.Email;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    public async Task SendProductAvailabilityNotificationAsync(string email, string productName)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Store Name", "yourstore@example.com")); 
        message.To.Add(new MailboxAddress("", email)); 
        message.Subject = "Product Availability Notification";

        message.Body = new TextPart("plain")
        {
            Text = $"Dear customer,\n\nThe product '{productName}' is now available. You can place your order now.\n\nBest regards,\nYour Store Team"
        };

        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync("smtp.example.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("yourstore@example.com", "your-email-password");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to send email notification.", ex);
            }
        }
    }
}
