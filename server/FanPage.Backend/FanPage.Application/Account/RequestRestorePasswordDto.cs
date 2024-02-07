using FanPage.Application.Url;

namespace FanPage.Application.Account
{
    public class RequestRestorePasswordDto
    {
        public string? Email { get; set; }

        public UrlInformationDto? RestorePasswordUrl { get; set; }
    }
}