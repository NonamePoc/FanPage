using System.ComponentModel.DataAnnotations;


namespace FanPage.Domain.Entities.Identity
{
    public class Friendship
    {
        [Key] public int FriendshipId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public string FriendName { get; set; }
        public User Friend { get; set; }
    }
}