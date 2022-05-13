using ArtGallery.Data;
using ArtGallery.Models;

namespace ArtGallery.Providers
{
    public class ArtProvider: IArtProvider
    {
        private readonly ArtGalleryDbContext _dbContext;
        public ArtProvider(ArtGalleryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<Art> QueryArt() => _dbContext.Arts.AsQueryable();

        public Art GetArtById(int id)
        {
            try
            {
                Art requiredArt = _dbContext.Arts.First(a => a.Id == id);
                return requiredArt;
            } 
            catch (Exception ex)
            {
                throw new Exception("Ops! Art with this id is not found!");
            }
        }

        public Art AddArt(string title, string artist, string imageUrl, int year, string type, ArtType artType, string? technique)
        {
            Art art = new Art
            {
                Title = title,
                ImageUrl = imageUrl,
                Artist = artist,
                Year = year,
                Type = type,
                ArtType = artType,
                Technique = technique
            };
            _dbContext.Arts.Add(art);
            _dbContext.SaveChanges();
            return art;
        }

        public Art UpdateArt(int id, ArtType artType, string? title, string? imageUrl, string? artist, int? year, string? type, string? technique)
        {
            Art art = GetArtById(id);
            if (art == null) throw new Exception("Ops! Art with this id is not found!");
            if (title != null) art.Title = title;
            if (artist != null) art.Artist = artist;
            if (year != null) art.Year = (int) year;
            if (imageUrl != null) art.ImageUrl = imageUrl;
            if (type != null) art.Type = type;
            if (artType == ArtType.Painting && technique != null) art.Technique = technique;
            _dbContext.SaveChanges();
            return art;
        }

        public void DeleteArt(int id)
        {
            Art art = GetArtById(id);
            _dbContext.Arts.Remove(art);
            _dbContext.SaveChanges();
        }
    }
}