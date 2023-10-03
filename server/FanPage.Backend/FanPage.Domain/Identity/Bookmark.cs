using FanPage.Domain.Fanfik;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Identity
{
    public class Bookmark
    {
        [Key]
        public int BookmarkId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int FanficId { get; set; }
        public Fanfic Fanfic { get; set; }
    }
}
