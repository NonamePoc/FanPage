namespace FanPage.Application.Chat;

public class MessageDto
{

    public string Content { get; set; }

    public DateTimeOffset ReceivedDateUtc { get; set; }
    
    public int ChatId { get; set; }

    public string UserId { get; set; }

    public string UserName { get; set; }

    public string SenderAvatar { get; set; }
}