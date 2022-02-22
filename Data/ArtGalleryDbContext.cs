using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Data
{
    public class ArtGalleryDbContext : DbContext
    {

        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Art> Arts { get; set; }
    }
}
