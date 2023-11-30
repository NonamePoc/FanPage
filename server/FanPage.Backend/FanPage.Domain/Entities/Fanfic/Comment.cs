using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Entities.Fanfic
{
    public class Comment : IEntity
    {
        [Key] public int CommentId { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int FanficId { get; set; }

        [ForeignKey("FanficId")] public Entities.Fanfic.Fanfic Fanfic { get; set; }

        public ICollection<CommentPhoto> CommentPhoto { get; set; }
    }
}