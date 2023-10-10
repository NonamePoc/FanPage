using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Entities.Identity
{
    public class Sticker
    {
        [Key]
        public int StickerId { get; set; }

        public string ImageUrl { get; set; }

        public int CustomizationSettingsId { get; set; }

        [ForeignKey("CustomizationSettingsId")]
        public CustomizationSettings CustomizationSettings { get; set; }
    }
}
