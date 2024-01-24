namespace FanPage.Domain.Chat.Entities;

public class Chat : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Type { get; set; }
    
    public string AuthorName { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; }

    public ICollection<Message> Messages { get; set; }
}