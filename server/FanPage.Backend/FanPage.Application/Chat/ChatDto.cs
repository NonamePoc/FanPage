namespace FanPage.Application.Chat;

public class ChatDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public string AuthorName { get; set; }

    public ICollection<ChatUserDto> ChatUsers { get; set; }

    public ICollection<MessageDto> Messages { get; set; }
}