using FanPage.EmailService.Models;


namespace FanPage.EmailService.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync (EmailRequest emailRequest);
    }
}
