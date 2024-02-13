using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }


        public async Task<ActionResult> Index()
        {
            var userParks = await _dashboardRepository.GetUsersParks();

            DashboardVM dashboardVM = new DashboardVM()
            {
                Parks = userParks
            };

            return View(dashboardVM);
        }
    }
}
