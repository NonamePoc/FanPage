namespace FanPage.Application.Admin
{
    public class UserBanInfoResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DateTimeOffset? BanTime { get; set; }
    }
}
