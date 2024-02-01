using Microsoft.AspNetCore.Mvc;

namespace StreetWorkoutWebApp.Controllers
{
    public class ParkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
