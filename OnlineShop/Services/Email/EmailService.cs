using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineShop.Models.Email;

namespace OnlineShop.Services.Email
{
    public class EmailService : IEmailService
    {
        #region Properties

        private readonly EmailSettings _emailSettings;

        #endregion

        #region Constructor

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        #endregion

        #region Methods

        public async Task SendEmailAsync(EmailRequestDto emailRequestDto)
        {
            try
            {
                if (string.IsNullOrEmpty(emailRequestDto.ToEmail))
                    throw new ArgumentException("Recipient email is required.");
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse("vidaz7575@gmail.com");
                email.To.Add(MailboxAddress.Parse(emailRequestDto.ToEmail));
                email.Subject = emailRequestDto.Subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = emailRequestDto.Body
                };

                if (emailRequestDto.Attachments != null)
                {
                    byte[] fileBytes;

                    foreach (var file in emailRequestDto.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();

                                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                            }
                        }
                    }
                }

                builder.HtmlBody = emailRequestDto.Body;
                email.Body = builder.ToMessageBody();

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("SMTP", 0, SecureSocketOptions.StartTls);
                    smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);

                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Failed to send email.", ex);
            }
        }
    }
}
                #endregion
           