using MailKit.Net.Smtp;
using MimeKit;
using OnlineShop.Services.Email;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string email, string textMessage)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Store Name", "yourstore@example.com")); 
        message.To.Add(new MailboxAddress("", email)); 
        message.Subject = "Product Availability Notification";

        message.Body = new TextPart("plain")
        {
            Text = textMessage
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

    public async Task<string> FillTextMessageAsync(string textMessage, string code, int number, string firstName)
    {
        switch (number)
        {
            case 1:
                textMessage = $"Dear {firstName} Product {code} is available";
                break;
            case 2:
                textMessage = $"Dear {firstName} login code is {code}";
                break;
        }
        return textMessage;
    }
}
