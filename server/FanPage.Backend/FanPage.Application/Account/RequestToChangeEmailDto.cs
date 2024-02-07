using FanPage.Application.Url;

namespace FanPage.Application.Account
{
    public class RequestToChangeEmailDto
    {
        public string NewEmail { get; set; }

        public UrlInformationDto ChangeEmailUrl { get; set; }
    }
}