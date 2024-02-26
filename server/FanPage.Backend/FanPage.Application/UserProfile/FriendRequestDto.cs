namespace FanPage.Application.UserProfile
{
    public class FriendRequestDto
    {
        public string UserName{ get; set;}
        public string FriendName { get; set;}

        public byte[] userAvatar { get; set;}
        public byte[] friendAvatar { get; set; }

        public bool IsApproving { get; set;}
    }
}
