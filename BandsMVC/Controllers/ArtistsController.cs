using BandsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandsMVC.Controllers
{
    public class ArtistsController : Controller
    {
        private BandsDbContext db;
        public ArtistsController(BandsDbContext context)
        {
            db = context;
            if(!db.Artists.Any())
            {
                db.Artists.Add(new Artist { Name = "John", Surname = "Lennon", BirthDate = "9/10/1940", Type = "singer" });
                db.Artists.Add(new Artist { Name = "James Paul", Surname = "McCartney", BirthDate = "18/06/1942", Type = "bassist" });
                db.Artists.Add(new Artist { Name = "George", Surname = "Harrison", BirthDate = "25/2/1943", Type = "singer/guitarist" });
                db.Artists.Add(new Artist { Name = "Richard", Surname = "Starkey", BirthDate = "7/7/1940", Type = "drummer" });
            }
            db.SaveChanges();

        }
        public IActionResult Index()
        {
            return View(db.Artists.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var artist = new Artist();
            return View(artist);
        }
        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            { 
                if (artist.Id == 0)
                    db.Artists.Add(artist);
                else
                    db.Artists.Update(artist);
                db.SaveChanges();
                return View("Index", db.Artists.ToList());
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Edit(Artist artist)
        {
            return View("Create", artist);
        }
        
        public IActionResult Delete(Artist artist)
        {            
            db.Artists.Remove(artist);
            db.SaveChanges();
            return View("Index", db.Artists.ToList());
        }
        
    }
}
