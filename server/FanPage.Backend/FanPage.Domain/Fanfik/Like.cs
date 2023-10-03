using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanPage.Domain.Identity;

namespace FanPage.Domain.Fanfik
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int FanficId { get; set; }

        [ForeignKey("FanficId")]
        public Fanfic Fanfic { get; set; }
    }
}
