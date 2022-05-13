using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    [Table("user")]
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

        public User()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Password = "";
            this.Type = UserType.Unknown;
        }

        public User(string firstName, string lastName, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public string[] Convert()
        {
            string[] result = new string[4];
            result[0] = this.FirstName;
            result[1] = this.LastName;
            result[2] = this.Email;
            result[3] = this.Password;
            return result;
        }
    }
}
