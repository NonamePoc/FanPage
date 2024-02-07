using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Account.Entities
{
    public class Sticker
    {
        [Key] public int StickerId { get; set; }

        public byte[] Image { get; set; }

        public int CustomizationSettingsId { get; set; }

        [ForeignKey("CustomizationSettingsId")]
        public CustomizationSettings CustomizationSettings { get; set; }
    }
}