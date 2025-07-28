using Microsoft.EntityFrameworkCore;
using Pictures.Domain.Entities;

namespace Pictures.Infrastructure.Data
{
    public class PictureDbContext : DbContext
    {
        public PictureDbContext(DbContextOptions<PictureDbContext> options) : base(options) { }

        public DbSet<Picture> Pictures => Set<Picture>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).HasMaxLength(250);
                entity.Property(p => p.FileContent).IsRequired();
                entity.Property(p => p.FileName).IsRequired().HasMaxLength(255);
                entity.HasIndex(p => p.FileName); // Add index on FileName
            });
        }
    }
}
