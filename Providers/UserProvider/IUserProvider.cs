using ArtGallery.Models;

namespace ArtGallery.Providers.UserProvider
{
    public interface IUserProvider
    {
        public IQueryable<User> QueryUsers();
        public User AddUser(string firstName, string lastName, string email, string password, UserType type);
        public User GetUserByEmail(string email);
        public UserType CheckUserCreditentials(string email, string password);

        public User UpdateUser(string email, string? firstName, string? lastName, string? password, UserType? type);
        public void DeleteUser(string email); 
    }
}
