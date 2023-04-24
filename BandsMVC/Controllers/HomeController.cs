using BandsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BandsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BandsDbContext db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = new BandsDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bands()
        {
            return Redirect("~/Bands/AllBands");
        }
        public IActionResult Artists()
        {
            return Redirect("~/Artists/Index");
        }
        public IActionResult Albums()
        {
            return Redirect("~/Albums/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}