using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtGallery.Data
{
    public class ArtGalleryDbContext : DbContext
    {
        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder
                .Entity<Art>()
                .Property(d => d.ArtType)
                .HasConversion<string>();
        }

        public DbSet<Art> Arts { get; set; }
        public DbSet<User> Users { get; set; } 

        public DbSet<Institution> Institutions { get; set; }
    }
}
