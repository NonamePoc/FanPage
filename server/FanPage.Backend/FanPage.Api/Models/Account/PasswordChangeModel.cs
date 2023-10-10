namespace FanPage.Api.Models.Account
{
    public class PasswordChangeModel
    {
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? NewPassword { get; set; }
    }
}
