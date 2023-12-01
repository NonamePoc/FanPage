using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Entities.Fanfic
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int FanficId { get; set; }

        [ForeignKey("FanficId")] public Entities.Fanfic.Fanfic Fanfic { get; set; }
    }
}