namespace FanPage.Domain.Entities.Fanfic
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }


        public ICollection<FanficCategory> FanficCategories { get; set; }
    }
}