namespace FanPage.Api.Models.Account
{
    public class RegistrationModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}