using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Controllers
{
    public class ParkController : Controller
    {
        private readonly IParkRepository _parkRepository;

        public ParkController(IParkRepository parkRepository)
        {
            _parkRepository = parkRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Park> parks = await _parkRepository.GetAll(); 
            return View(parks);
        }

        public async Task<IActionResult> Details(int id)
        {
            Park park = await _parkRepository.GetByIdAsync(id);
            return View(park);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Park park)
        {
            if(!ModelState.IsValid)
            {
                return View(park);
            }
            _parkRepository.Add(park);
            return RedirectToAction("Index");
        }
    }
}
