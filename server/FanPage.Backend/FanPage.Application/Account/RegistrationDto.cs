using FanPage.Application.Url;

namespace FanPage.Application.Account
{
    public class RegistrationDto
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public UrlInformationDto ConfirmEmailUrl { get; set; }
    }
}