using ArtGallery.Data;
using ArtGallery.Models;

namespace ArtGallery.Providers.UserProvider
{
    public class UserProvider : IUserProvider
    {
        private readonly ArtGalleryDbContext _dbContext;

        public UserProvider(ArtGalleryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User AddUser(string firstName, string lastName, string email, string password, UserType type)
        {
            User user = new User
            { 
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Type = type
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                User requiredUser = _dbContext.Users.First(u => u.Email == email);
                return requiredUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Ops! User with this email is not found!");
            }
        }

        public UserType CheckUserCreditentials(string email, string password)
        {
            try
            {
                User requiredUser = _dbContext.Users.First(u => u.Email == email && u.Password == password);
                return requiredUser.Type;
            }
            catch (Exception ex)
            {
                throw new Exception("Ops! User with this creditentials is not found!");
            }
        }

        public IQueryable<User> QueryUsers() => _dbContext.Users.AsQueryable();

        public User UpdateUser(string email, string? firstName, string? lastName, string? password, UserType? type)
        {
            User user = GetUserByEmail(email);
            if (user == null) throw new Exception("Ops! User with this creditentials is not found!");
            if (firstName != null)
            {
                user.FirstName = firstName;
            }
            if (lastName != null)
            {
                user.LastName = lastName;
            }
            if (password != null)
            {
                user.Password = password;
            }
            if(type != null)
            {
                user.Type = (UserType)type;
            }
            _dbContext.SaveChanges();
            return user;

        }

        public void DeleteUser(string email)
        {
            User user = GetUserByEmail(email);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
