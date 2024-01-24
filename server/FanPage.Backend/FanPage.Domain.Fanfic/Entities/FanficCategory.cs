using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Fanfic.Entities
{
    public class FanficCategory : IEntity
    {
        [Key] public int Id { get; set; }
        public int FanficId { get; set; }
        [ForeignKey("FanficId")] public Fanfic Fanfic { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] public Category Category { get; set; }
    }
}