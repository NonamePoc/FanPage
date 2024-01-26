using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Entities.Identity
{
    public class FriendRequest
    {
        [Key] public int FriendRequestId { get; set; }
        public string UserName { get; set; }
        public string FriendName { get; set; }

        public bool IsApproving { get; set; }
    }
}
