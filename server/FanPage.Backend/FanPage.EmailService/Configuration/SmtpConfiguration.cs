namespace FanPage.EmailService.Configuration
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string EmailFrom { get; set; }
    }
}