namespace FanPage.Api.Models.Account
{
    public class RestorePasswordModel
    {
        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}