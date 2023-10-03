using FanPage.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Fanfik
{
    public class Fanfic
    {
        [Key]
        public int FanficId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        public int CategoryId { get; set; }


        public DateTime CreationDate { get; set; }

        public List<Like> Likes { get; set; }

        public List<Bookmark> Bookmarks { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
