namespace FanPage.Domain.Chat.Entities;

public class ChatUser
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public string UserName { get; set; }
    
    public Chat Chat { get; set; }
    
    public bool AcceptedRequest { get; set; }
    
    public int ChatId { get; set; }
}