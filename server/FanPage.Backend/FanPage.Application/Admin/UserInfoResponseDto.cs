namespace FanPage.Application.Admin
{
    public class UserInfoResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Role { get; set; }

        public string WhoBan { get; set; }
    }
}