namespace FanPage.Api.Models.Chat;

public class ChatModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<ChatUserModel>? Users { get; set; }

}