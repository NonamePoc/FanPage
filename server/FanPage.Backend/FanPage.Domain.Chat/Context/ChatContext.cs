using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Chat.Context;

public class ChatContext : DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
    }
    
    
    public DbSet<Entities.Chat> Chats { get; set; }
    
    public DbSet<Entities.Message> Messages { get; set; }
    
    public DbSet<Entities.ChatUser> ChatUsers { get; set; }
}