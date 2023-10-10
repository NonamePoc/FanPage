using FanPage.Domain.Entities.Fanfik;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Context
{
    public class FanfikContext : DbContext
    {
        public FanfikContext(DbContextOptions<FanfikContext> options) : base(options)
        {
        }

        public DbSet<Fanfic> Fanfics { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
