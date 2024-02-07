namespace FanPage.Domain.Fanfic.Entities
{
    public class Tag : IEntity
    {
        public int TagId { get; set; }
        public string? Name { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<FanficTag> FanficTags { get; set; }
    }
}