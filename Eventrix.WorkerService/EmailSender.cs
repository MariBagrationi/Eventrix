using System.Net;
using System.Net.Mail;

namespace Eventrix.WorkerService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendVerificationEmailAsync(string toEmail, string code, CancellationToken cancellationToken)
        {
            var smtpClient = new SmtpClient(_config["Email:Smtp"], int.Parse(_config["Email:Port"]!))
            {
                Credentials = new NetworkCredential(
                    _config["Email:Username"],
                    _config["Email:Password"]
                ),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Email:From"]!),
                Subject = "Your Verification Code",
                Body = $"Your verification code is: {code}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
