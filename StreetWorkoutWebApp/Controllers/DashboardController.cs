using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashboardRepository, IHttpContextAccessor httpContext, IPhotoService photoService)
        {
            _dashboardRepository = dashboardRepository;
            _httpContext = httpContext;
            _photoService = photoService;
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

        public async Task<IActionResult> EditUserProfile()
        {
            return View();
        }
    }
}
