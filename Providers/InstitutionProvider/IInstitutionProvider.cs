using ArtGallery.Models;

namespace ArtGallery.Providers.InstitutionProvider
{
    public interface IInstitutionProvider
    {
        public IQueryable<Institution> QueryInstitutions();
        public Institution AddInstitution(string name, string location);
        public Institution GetInstitutionById(int id);
        public Institution AddArtsToInstitution(int id, int[] ids);
        public List<Art> GetArtsOfInstitution(int id);
        public Institution UpdateInstitution(int id, string? name, string? location);
        public void DeleteInstitution(int id);
        public Institution[] GetInstitutions();
    }
}
