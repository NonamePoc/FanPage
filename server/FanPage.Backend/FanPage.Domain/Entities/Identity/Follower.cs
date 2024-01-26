using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Entities.Identity
{
    public class Follower
    {
        [Key] public int FollowerId{ get; set; }

        public string FollowerName { get; set; }    

        public string? UserName{ get; set; }
        public User? User { get; set; }
    }
}