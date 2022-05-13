using ArtGallery.Data;
using ArtGallery.Models;

namespace ArtGallery.Providers.InstitutionProvider
{
    public class InstitutionProvider : IInstitutionProvider
    {
        private readonly ArtGalleryDbContext _dbContext;

        public InstitutionProvider(ArtGalleryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Institution[] GetInstitutions()
        {
            var institutions = QueryInstitutions().ToArray();
            foreach (var institution in institutions)
            {
                var arts = GetArtsOfInstitution(institution.Id);
                institution.Arts = arts;
            }
            return institutions;
        }

        public Institution AddArtsToInstitution(int id, int[] ids)
        {
            Institution institution = GetInstitutionById(id);
            List<Art> arts = _dbContext.Arts.Where(a => ids.Contains(a.Id)).ToList();
            institution.Arts = arts;
            _dbContext.SaveChanges();
            return institution;
        }

        public Institution AddInstitution(string name, string location)
        {
            Institution institution = new()
            {
                Name = name,
                Location = location
            };
            _dbContext.Institutions.Add(institution);
            _dbContext.SaveChanges();
            return institution;
        }

        public void DeleteInstitution(int id)
        {
            Institution institution = GetInstitutionById(id);
            _dbContext.Institutions.Remove(institution);
            _dbContext.SaveChanges();
        }

        public List<Art> GetArtsOfInstitution(int id)
        {
            List<Art> arts = _dbContext.Arts.Where(a => a.InstitutionId == id).ToList();
            return arts;
        }

        public Institution GetInstitutionById(int id)
        {
            try
            {
                Institution requiredInstitution = _dbContext.Institutions.First(i => i.Id == id);
                return requiredInstitution;
            }
            catch (Exception ex)
            {
                throw new Exception("Ops! Institution with this id is not found!");
            }
        }

        public IQueryable<Institution> QueryInstitutions() => _dbContext.Institutions.AsQueryable();

        public Institution UpdateInstitution(int id, string? name, string? location)
        {
            Institution institution = GetInstitutionById(id);
            if (institution != null)
            {
                institution.Name = name;
            }
            if (location != null)
            {
                institution.Location = location;
            }
            _dbContext.SaveChanges();
            return institution;
        }
    }
}
