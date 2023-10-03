using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Identity
{
    public class User : IdentityUser
    {
        public string ProfilePictureUrl { get; set; }

        public int CustomizationSettingsId { get; set; }
        public CustomizationSettings CustomizationSettings { get; set; }

        [InverseProperty("User")]
        public ICollection<Friendship> MyFriends { get; set; }
        [InverseProperty("Friend")]
        public ICollection<Friendship> FriendsOfMine { get; set; }

        public ICollection<Follower> Followers { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
