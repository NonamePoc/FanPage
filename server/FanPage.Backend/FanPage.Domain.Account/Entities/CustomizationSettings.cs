using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Account.Entities
{
    public class CustomizationSettings
    {
        [Key] public int CustomizationSettingsId { get; set; }

        public ICollection<Sticker> CustomStickers { get; set; }
        
        public byte[]? BannerImage { get; set; }
    }
}