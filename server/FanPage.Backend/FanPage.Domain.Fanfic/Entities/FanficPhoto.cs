using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Fanfic.Entities
{
    public class FanficPhoto : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int FanficId { get; set; }

        [ForeignKey("FanficId")] public Fanfic Fanfic { get; set; }
    }
}