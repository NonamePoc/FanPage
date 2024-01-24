using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Fanfic.Entities;

public class Reviews : IEntity
{
    [Key] public int ReviewId { get; set; }

    public string UserName { get; set; }

    public string Text { get; set; }
    
    public double Rating { get; set; }
    
    public DateTimeOffset CreationDate { get; set; }

    public int FanficId { get; set; }

    public Fanfic Fanfic { get; set; }
}
