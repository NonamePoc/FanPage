namespace FanPage.Application.Account
{
    public class ChangePasswordDto
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}