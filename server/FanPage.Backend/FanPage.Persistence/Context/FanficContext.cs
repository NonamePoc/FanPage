using FanPage.Domain.Entities.Fanfic;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Context
{
    public class FanficContext : DbContext
    {
        public FanficContext(DbContextOptions<FanficContext> options) : base(options)
        {
        }

        public DbSet<Fanfic> Fanfic { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<FanficTag> FanficTags { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<FanficCategory> FanficCategories { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<FanficPhoto> FanficPhotos { get; set; }

        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<CommentPhoto> CommentPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FanficTag>()
                .HasKey(ft => new { ft.FanficId, ft.TagId });

            modelBuilder.Entity<FanficCategory>()
                .HasKey(fc => new { fc.FanficId, fc.CategoryId });
        }
    }
}