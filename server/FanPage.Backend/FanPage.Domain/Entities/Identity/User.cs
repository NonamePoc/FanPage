using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace FanPage.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public byte[]? UserAvatar { get; set; }
        public string? WhoBan { get; set; }
        public int CustomizationSettingsId { get; set; }
        public CustomizationSettings CustomizationSettings { get; set; }

        [InverseProperty("User")] public ICollection<Friendship> MyFriends { get; set; }
        [InverseProperty("Friend")] public ICollection<Friendship> FriendsOfMine { get; set; }

        public ICollection<Follower> Followers { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }

        public ICollection<Photo> Photos { get; set; }

    }
}