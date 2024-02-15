using Microsoft.AspNetCore.Mvc;

namespace StreetWorkoutWebApp.Controllers
{
    public class UserController : Controller
    {

        [HttpGet("users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
