namespace FanPage.Application.Chat;

public class MessageDto
{
    public string UserId { get; set; }

    public string Content { get; set; }

    public DateTimeOffset ReceivedDateUtc { get; set; }
    
    public int ChatId { get; set; }
}