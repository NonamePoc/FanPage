using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Fanfic.Entities
{
    public class Fanfic : IEntity
    {
        [Key] public int FanficId { get; set; }

        public ICollection<Chapter> Chapters { get; set; }

        public string Title { get; set; }
        public string AuthorName { get; set; }

        public string Language { get; set; }

        public string Stage { get; set; }
        public ICollection<FanficCategory> FanficCategories { get; set; }

        public ICollection<FanficTag> FanficTags { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public string Description { get; set; }

        public bool OriginFandom { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public ICollection<FanficPhoto> Photos { get; set; }

        public ICollection<Reviews> Reviews { get; set; }
    }
}