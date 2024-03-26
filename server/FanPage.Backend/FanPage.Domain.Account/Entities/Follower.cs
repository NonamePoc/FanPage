using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Account.Entities
{
    public class Follower
    {
        [Key] public int FollowerId { get; set; }

        public string UserName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }

        public string SubName { get; set; }
        public string SubId { get; set; }

        [ForeignKey("SubId")] public User Sub { get; set; }

    }
}