using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Account.Entities
{
    public class Friendship
    {
        [Key] public int FriendshipId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }

        public string FriendId { get; set; }

        [ForeignKey("FriendId")] public User Friend { get; set; }
    }
}