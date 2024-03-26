namespace FanPage.Api.ViewModels.User
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[]? Avatar { get; set; }
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Role { get; set; }

        public string WhoBan { get; set; }

    }
}