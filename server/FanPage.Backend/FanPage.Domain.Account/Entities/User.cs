using System.ComponentModel.DataAnnotations.Schema;
using FanPage.Domain.Account.Enum;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Domain.Account.Entities
{
    public class User : IdentityUser
    {
        public string UserAvatar { get; set; }

        public string WhoBan { get; set; }

        public int CustomizationSettingsId { get; set; }
        public CustomizationSettings CustomizationSettings { get; set; }
        [InverseProperty("User")] public ICollection<Follower> UserForSubscribe { get; set; }

        [InverseProperty("Sub")] public ICollection<Follower> Subcriber { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}
