namespace FanPage.Application.Chat;

public class ChatUserDto
{
    public string UserId { get; set; }
    
    public string UserName { get; set; }

    public string Avatar { get; set; }

    public int ChatId { get; set; }
    
    public bool AcceptedRequest {  get; set; } 
}