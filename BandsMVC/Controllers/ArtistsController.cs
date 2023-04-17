using BandsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandsMVC.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View(MemoryDB.Artists);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var artist = new Artist();            
            artist.Id = MemoryDB.Artists.Count>0 ? MemoryDB.Artists.Last().Id +1 : 0;
            return View(artist);
        }
        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                int index = MemoryDB.Artists.FindIndex(c => c.Id == artist.Id);
                if (index == -1)
                    MemoryDB.Artists.Add(artist);
                else
                    MemoryDB.Artists[index] = artist;
                return View("Index", MemoryDB.Artists);
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Edit(Artist artist)
        {
            return View("Create", artist);
        }
        
        public IActionResult Delete(int id)
        {
            int index = MemoryDB.Artists.FindIndex(c => c.Id == id);
            MemoryDB.Artists.RemoveAt(index);
            return View("Index", MemoryDB.Artists);
        }
        
    }
}
