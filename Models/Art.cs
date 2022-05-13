using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("2d6d2bb1-a612-463d-86d0-d7fb56604759")]

namespace ArtGallery.Models
{
    [Table("art")]
    public class Art
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; } 
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string? Technique { get; set; }
        [Column(TypeName = "Varchar(24)")]
        public ArtType ArtType { get; set; }
        public int? InstitutionId { get; set; }
        public Art()
        {
            Title = "";
            Artist = "";
            Year = 0;
            Type = "";
            Technique = null;
            ImageUrl = "";
            ArtType = ArtType.Unknown;
        }
        public Art(string title, string imageUrl, string artistName, int year, string type, ArtType artType, string? technique)
        {
            this.Title = title;
            this.ImageUrl = imageUrl;
            this.Artist = artistName;
            this.Year = year;
            this.Type = type;
            this.Technique = technique;
            this.ArtType = artType;
        }
    }
}

