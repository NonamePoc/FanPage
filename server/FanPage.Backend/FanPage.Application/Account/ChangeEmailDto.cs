namespace FanPage.Application.Account
{
    public class ChangeEmailDto
    {
        public string? Email { get; set; }

        public string? NewEmail { get; set; }

        public string? Token { get; set; }
    }
}