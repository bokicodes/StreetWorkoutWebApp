using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Helpers;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;
using System.Diagnostics;

namespace StreetWorkoutWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IParkRepository _parkRepository;

        public HomeController(ILogger<HomeController> logger, IParkRepository parkRepository)
        {
            _logger = logger;
            _parkRepository = parkRepository;
        }

        public IActionResult Index()
        {
            var ipInfo = new IPInfo();
            var 

            return View();
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