using FanPage.EmailService.Interfaces;
using FanPage.EmailService.Models;
using FanPage.EmailService.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace FanPage.EmailService.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly SmtpConfiguration _configuration;

        public EmailService(SmtpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(EmailRequest request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.EmailFrom));
            email.To.Add(MailboxAddress.Parse(request.EmailTo));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Html };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration.Host, _configuration.Port);
            await smtp.AuthenticateAsync(_configuration.Login, _configuration.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}