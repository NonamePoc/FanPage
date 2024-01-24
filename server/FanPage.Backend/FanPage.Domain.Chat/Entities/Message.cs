namespace FanPage.Domain.Chat.Entities;

public class Message : IEntity
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string Content { get; set; }

    public DateTimeOffset ReceivedDateUtc { get; set; }

    public Chat Chat { get; set; }

    public int ChatId { get; set; }
}