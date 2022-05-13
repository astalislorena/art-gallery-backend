using ArtGallery.Models;

namespace ArtGallery.Providers
{
    public interface IArtProvider
    {
        public IQueryable<Art> QueryArt();
        public Art AddArt(string title, string artist, string imageUrl, int year, string type, ArtType artType, string? technique);
        public Art GetArtById(int id);
        public Art UpdateArt(int id, ArtType artType, string? imageUrl, string? title, string? artist, int? year, string? type, string? technique);
        public void DeleteArt(int id);
    }
}