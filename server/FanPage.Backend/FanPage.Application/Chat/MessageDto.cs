namespace FanPage.Application.Chat;

public class MessageDto
{

    public string Content { get; set; }

    public DateTimeOffset ReceivedDateUtc { get; set; }
    
    public int ChatId { get; set; }

    public int SenderId { get; set; }
}