using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandsMVC.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public int Year { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        [NotMapped]
        public int[]? SelectedArtistsId { get; set; }
        public Band()
        {
            Name = "New band";
            Year = 2022;
            Artists = new List<Artist>();
            Albums = new List<Album>();
        }
        
    }
}
