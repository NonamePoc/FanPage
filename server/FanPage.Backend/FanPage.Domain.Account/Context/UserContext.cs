using FanPage.Domain.Account.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Context
{
    public class UserContext : IdentityDbContext<Entities.User>
    {
        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<CustomizationSettings> CustomizationSettings { get; set; }

        public DbSet<Follower> Followers { get; set; }
        public DbSet<Sticker> Stickers { get; set; }

        public DbSet<Photo> Photos { get; set; }
        
        public UserContext(DbContextOptions<UserContext> options) :
            base(options)
        {
        }
    }
}