using BandsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandsMVC.Controllers
{
    public class BandsController : Controller
    {
        
        public IActionResult AllBands()
        {
            ViewData["Title"] = "All bands";
            return View(MemoryDB.Bands);
        }
        [HttpGet]
        public IActionResult Create()
        {
           var band = new Band();
            band.Id = MemoryDB.Bands.Count > 0 ? MemoryDB.Bands.Last().Id + 1 : 0;
            ViewBag.Artists = MemoryDB.Artists.Select(a=> new {Name = a.Name+" "+a.Surname, Id = a.Id});
            return View(band);
        }
        [HttpPost]
        public IActionResult Create(Band band)
        {
            if (ModelState.IsValid)
            {
                int index = MemoryDB.Bands.FindIndex(c => c.Id == band.Id);
                if (index == -1)
                {
                    MemoryDB.Bands.Add(band);
                    index = MemoryDB.Bands.Count-1;
                }
                if (band.SelectedArtistsId != null)
                {                    
                    foreach (var i in band.SelectedArtistsId)
                    {
                        var artist = MemoryDB.Artists.Find(a => a.Id == i);
                        if (!MemoryDB.Bands[index].Artists.Contains(artist))
                            MemoryDB.Bands[index].Artists.Add(artist);
                    }
                }
                MemoryDB.Bands[index].Name = band.Name;
                MemoryDB.Bands[index].Country = band.Country;
                MemoryDB.Bands[index].Year = band.Year;
                return View("AllBands", MemoryDB.Bands);
            }
            else return View();
            
        }
        public IActionResult Edit(int id)
        {
            int index = MemoryDB.Bands.FindIndex(c => c.Id == id);
            var band = MemoryDB.Bands[index];
            ViewBag.Artists = MemoryDB.Artists.Select(a => new { Name = a.Name + " " + a.Surname, Id = a.Id });
            return View("Create", band);
        }
        public IActionResult Delete(int id)
        {
            int index = MemoryDB.Bands.FindIndex(b => b.Id == id);
            MemoryDB.Bands.RemoveAt(index);
            return View("AllBands", MemoryDB.Bands);
        }
        public IActionResult ShowDetails(int id)
        {
            int index = MemoryDB.Bands.FindIndex(c => c.Id == id);
            var band = MemoryDB.Bands[index];
            return View(band);
        }
       

    }
}
