using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Entities.Identity
{
    public class CustomizationSettings
    {
        [Key]
        public int CustomizationSettingsId { get; set; }

        public string BannerUrl { get; set; } = string.Empty;

        public ICollection<Sticker> CustomStickers { get; set; }

    }
}
