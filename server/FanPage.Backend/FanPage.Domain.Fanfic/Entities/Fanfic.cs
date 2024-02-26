using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Fanfic.Entities
{
    public class Fanfic : IEntity
    {
        [Key] public int FanficId { get; set; }

        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();

        public string Title { get; set; }
        public string AuthorName { get; set; }

        public string Language { get; set; }

        public string Stage { get; set; }
        public ICollection<FanficCategory> FanficCategories { get; set; } = new List<FanficCategory>();

        public ICollection<FanficTag> FanficTags { get; set; } = new List<FanficTag>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string? Description { get; set; }

        public bool OriginFandom { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public ICollection<FanficPhoto> Photos { get; set; } = new List<FanficPhoto>();

        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    }
}