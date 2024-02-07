namespace FanPage.Common.Configurations
{
    public class JwtConfiguration
    {
        public TimeSpan LifeTime { get; set; }

        public string? Key { get; set; }

        public TimeSpan BlackListLifeTime { get; set; }
    }
}