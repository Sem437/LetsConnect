using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace LetsConnect.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailConfig = _configuration.GetSection("Email"); // Haalt Email op uit appsettings.json
            using (var client = new SmtpClient(emailConfig["Host"], int.Parse(emailConfig["Port"]))) //int.Parse(emailConfig["Port"]) maakt de port naar een string
            {
                client.Credentials = new NetworkCredential(emailConfig["Username"], emailConfig["Password"]); // Stelt inloggegevens in voor SMTP server
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailConfig["Username"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
