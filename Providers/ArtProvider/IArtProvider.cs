using ArtGallery.Models;

namespace ArtGallery.Providers
{
    public interface IArtProvider
    {
        public IQueryable<Art> QueryArt();
        public Art AddArt(string name, string imageUrl);
        public Art GetArtById(int id);
    }
}