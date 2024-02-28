namespace FanPage.Application.UserProfile
{
    public class FriendDto
    {
        public string UserName { get; set; }
        public string FriendName { get; set; }

        public byte[] userAvatar { get; set; }

        public byte[] friendAvatar { get; set; }
    }
}