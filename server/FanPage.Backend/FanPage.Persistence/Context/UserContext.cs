using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FanPage.Domain.Entities.Identity;

namespace FanPage.Persistence.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<CustomizationSettings> CustomizationSettings { get; set; }

        public DbSet<Follower> Followers { get; set; }

        public DbSet<Friendship> Friendships { get; set; }


        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Sticker> Stickers { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public IEnumerable<object> Friendship { get; internal set; }

        public UserContext(DbContextOptions<UserContext> options) :
            base(options)
        {
        }
    }
}