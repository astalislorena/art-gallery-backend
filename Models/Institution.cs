using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    [Table("instutution")]
    public class Institution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Art> Arts { get; set; }

        public Institution()
        {
            this.Id = 0;
            this.Name = "";
            this.Location = "";
            this.Arts = new List<Art>();
        }

        public Institution(string name, string location) : this()
        {
            this.Name = name;
            this.Location = location;
        }
    }
}
