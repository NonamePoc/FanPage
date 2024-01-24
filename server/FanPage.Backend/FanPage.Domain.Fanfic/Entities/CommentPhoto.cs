using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Fanfic.Entities
{
    public class CommentPhoto : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int CommentId { get; set; }

        [ForeignKey("CommentId")] public Comment Comment { get; set; }
    }
}