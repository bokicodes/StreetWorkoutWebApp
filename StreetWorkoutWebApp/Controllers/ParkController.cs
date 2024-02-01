using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Controllers
{
    public class ParkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Park> parks = _context.Parks.ToList();
            return View(parks);
        }
    }
}
