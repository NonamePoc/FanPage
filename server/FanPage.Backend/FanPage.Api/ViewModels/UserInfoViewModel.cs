namespace FanPage.Api.ViewModels
{
    public class UserInfoViewModel
    {
        public bool IsBanned { get; set; }
        public DateTimeOffset? BanExpirationDate { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }

    }
}
