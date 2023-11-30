using System.ComponentModel.DataAnnotations;


namespace FanPage.Domain.Entities.Identity
{
    public class Friendship
    {
        [Key] public int FriendshipId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FriendId { get; set; }
        public User Friend { get; set; }
    }
}