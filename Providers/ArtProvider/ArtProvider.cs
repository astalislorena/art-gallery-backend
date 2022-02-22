using ArtGallery.Data;
using ArtGallery.Models;

namespace ArtGallery.Providers
{
    public class ArtProvider: IArtProvider
    {
        private readonly ArtGalleryDbContext _dbContext;

        public ArtProvider(ArtGalleryDbContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public IQueryable<Art> QueryArt() => _dbContext.Arts.AsQueryable();

        public Art AddArt(string name, string imageUrl)
        {
            Art art = new Art
            {
                Name = name,
                ImageUrl = imageUrl
            };
            _dbContext.Arts.Add(art);
            _dbContext.SaveChanges();
            return art;
        }

        public Art GetArtById(int id)
        {
            try
            {
                Art requiredArt = new Art { Id = id };
                return requiredArt;
            } 
            catch (Exception ex)
            {
                throw new Exception("Art with this id is not found");
            }
        }


    }
}