using Microsoft.AspNetCore.Mvc.Rendering;

namespace BandsMVC.Models
{
    public static class MemoryDB
    {
        public static List<Band> Bands { get; set; } = new ()
        {
            new Band { Id=0, Name = "The Beatles", Year = 1960, Country = "England" },
            new Band { Id=1,Name = "Genesis", Country = "England" },
            new Band { Id=2,Name = "ABBA", Year = 1974, Country = "Sweden" },
            new Band { Id=3, Name = "Sonic Youth", Year = 1990, Country = "USA" }
        };

        public static List<Artist> Artists { get; set; } = new()
        {
            new Artist { Id = 0, Name = "John", Surname ="Lennon", BirthDate = "9/10/1940", Type = "singer"},
            new Artist { Id = 1, Name = "James Paul", Surname ="McCartney", BirthDate = "18/06/1942", Type = "bassist"},
            new Artist { Id = 2,Name = "George", Surname ="Harrison", BirthDate = "25/2/1943", Type = "singer/guitarist"},
            new Artist { Id= 3, Name = "Richard", Surname ="Starkey", BirthDate = "7/7/1940", Type = "drummer"}
        };

        public static List<Album> Albums { get; set; } = new()
        {
            new Album{Id = 0, Name = "Abbey Road", Year = 1969, Band = Bands[0]},
            new Album{Id = 1, Name="Revolver", Year = 1966, Band = Bands[0]},
            new Album{Id = 2, Name = "Please Please Me", Year = 1963, Band = Bands[0]},
            new Album{Id = 3, Name = "Help!", Year = 1965, Band = Bands[0]},
            new Album{Id = 4, Name = "Let It Be", Year = 1970, Band = Bands[0]},
            new Album{Id = 5, Name = "The Beatles", Year = 1968, Band = Bands[0]},
        };
       
        
    }
}
