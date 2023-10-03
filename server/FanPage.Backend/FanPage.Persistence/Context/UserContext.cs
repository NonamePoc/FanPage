using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanPage.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<CustomizationSettings> CustomizationSettings { get; set; }

        public DbSet<Follower> Followers { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public UserContext(DbContextOptions<UserContext> options) :
        base(options)
        {
        }
    }
}
