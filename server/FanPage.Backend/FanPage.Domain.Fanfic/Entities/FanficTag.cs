using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Fanfic.Entities
{
    public class FanficTag : IEntity
    {
        [Key] public int Id { get; set; }
        public int FanficId { get; set; }
        [ForeignKey("FanficId")] public Fanfic Fanfic { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")] public Tag Tag { get; set; }
    }
}