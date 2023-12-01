using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Entities.Fanfic
{
    public class FanficCategory : IEntity
    {
        [Key] public int Id { get; set; }
        public int FanficId { get; set; }
        [ForeignKey("FanficId")] public Entities.Fanfic.Fanfic Fanfic { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] public Category Category { get; set; }
    }
}