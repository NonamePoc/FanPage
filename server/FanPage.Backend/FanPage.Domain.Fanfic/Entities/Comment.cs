using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Fanfic.Entities
{
    public class Comment : IEntity
    {
        [Key] public int CommentId { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

 
        public int FanficId { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        [ForeignKey("FanficId")] public Fanfic Fanfic { get; set; }

    }
}