namespace FanPage.Application.Admin
{
    public class UserBanInfoResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string AdminName { get; set; }

        public DateTimeOffset? BanTime { get; set; }
    }
}
