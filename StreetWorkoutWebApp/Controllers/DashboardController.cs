using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;

namespace StreetWorkoutWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
