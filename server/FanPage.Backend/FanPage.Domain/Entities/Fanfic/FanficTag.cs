using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Entities.Fanfic
{
    public class FanficTag : IEntity
    {
        [Key] public int Id { get; set; }
        public int FanficId { get; set; }
        [ForeignKey("FanficId")] public Entities.Fanfic.Fanfic Fanfic { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")] public Tag Tag { get; set; }
    }
}