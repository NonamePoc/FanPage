namespace FanPage.Api.Models.Account
{
    public class ChangeEmailModel
    {
        public string? Email { get; set; }

        public string? NewEmail { get; set; }

        public string? Token { get; set; }
    }
}