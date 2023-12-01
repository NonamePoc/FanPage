using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Fanfic
{
    public class FanficPhotoCommentDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int CommentId { get; set; }
    }
}