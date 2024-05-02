using FanPage.Domain.Chat.Entities;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Chat.Context;

public class ChatContext : DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options) : base(options)
    {
    }
    
    
    public DbSet<Entities.Chat> Chats { get; set; }
    
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<ChatUser> ChatUsers { get; set; }
}