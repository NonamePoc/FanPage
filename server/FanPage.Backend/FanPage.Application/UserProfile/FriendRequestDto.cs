namespace FanPage.Application.UserProfile
{
    public class FriendRequestDto
    {
        public string UserName { get; set; }
        public string FriendName { get; set; }
        public string friendAvatar { get; set; }

        public bool IsApproving { get; set; }
    }
}
