using FanPage.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Entities.Fanfik
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int FanficId { get; set; }

        [ForeignKey("FanficId")]
        public Fanfic Fanfic { get; set; }
    }
}
