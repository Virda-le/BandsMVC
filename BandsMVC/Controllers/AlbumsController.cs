using BandsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BandsMVC.Controllers
{
    public class AlbumsController : Controller
    {
        public IActionResult Index()
        {            
            return View(MemoryDB.Albums);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Bands = MemoryDB.Bands;
            var album = new Album();
            album.Id = MemoryDB.Albums.Count > 0 ? MemoryDB.Albums.Last().Id + 1 : 0;
            return View(album);
        }
        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                //index for adding album to band
                int idxBand = MemoryDB.Bands.FindIndex(b=>b.Id == album.Band.Id);
                //check if album exist
                int index = MemoryDB.Albums.FindIndex(c => c.Id == album.Id);
                album.Band = MemoryDB.Bands[idxBand];
                if (index == -1)
                {
                    MemoryDB.Albums.Add(album);                    
                    MemoryDB.Bands[idxBand].Albums.Add(album);
                }
                //edit 
                else
                {
                    if(!MemoryDB.Bands[idxBand].Albums.Contains(album))
                        MemoryDB.Bands[idxBand].Albums.Add(album);
                    //find previous Band index and if it changed or not
                    int idxPr = MemoryDB.Bands.FindIndex(c => c.Id == (MemoryDB.Albums[index].Band.Id));
                    if (idxPr != idxBand)
                     // if band changed than delete album from prev one and add to new one
                        MemoryDB.Bands[idxPr].Albums?.Remove(MemoryDB.Albums[index]);
                        
                    
                    MemoryDB.Albums[index] = album;
                }
                return View("Index", MemoryDB.Albums);
            }
            else
                return View();
        }        
        public IActionResult Edit(int id)
        {
            ViewBag.Bands = MemoryDB.Bands;
            var album = MemoryDB.Albums.Find(a => a.Id == id);
            return View("Create",album);
        }
       public IActionResult Delete(int id)
        {
            int index = MemoryDB.Albums.FindIndex(a => a.Id == id);
            MemoryDB.Albums.RemoveAt(index);
            return View("Index",MemoryDB.Albums);
        }
    }
}
