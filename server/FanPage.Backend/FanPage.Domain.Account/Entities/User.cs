using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Domain.Account.Entities
{
    public class User : IdentityUser
    {
        public byte[]? UserAvatar { get; set; }

        public string WhoBan { get; set; }
        
        public int CustomizationSettingsId { get; set; }
        public CustomizationSettings CustomizationSettings { get; set; }

        [InverseProperty("User")] public ICollection<Friendship> MyFriends { get; set; }

        [InverseProperty("Friend")] public ICollection<Friendship> FriendsOfMine { get; set; }

        [InverseProperty("User")] public ICollection<Follower> UserForSubscribe { get; set; }

        [InverseProperty("Sub")] public ICollection<Follower> Subcriber { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }

        public ICollection<Photo> Photos { get; set; }

        [InverseProperty("User")] public ICollection<FriendRequest> SentFriendRequests { get; set; }

        [InverseProperty("Friend")] public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
    }
}