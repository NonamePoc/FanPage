namespace FanPage.Domain.Fanfic.Entities
{
    public class Chapter : IEntity
    {
        public int ChapterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreateDate { get; set; }
        
        public int FanficId { get; set; }

        public Fanfic Fanfic { get; set; }
    }
}
