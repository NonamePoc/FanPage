namespace FanPage.Application.Account
{
    public class RestorePasswordDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}