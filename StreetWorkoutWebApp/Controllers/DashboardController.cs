using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;
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
            var userId = _httpContext.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(userId);

            if (user == null)
                return View("Error");

            var editUserVM = new EditUserProfileVM
            {
                Id = userId,
                City = user.City,
                Country = user.Country,
                ProfileImageUrl = user.ProfileImageUrl,
            };

            return View(editUserVM);
        }

        private void MapUserEdit(AppUser user, EditUserProfileVM editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.City = editVM.City;
            user.Country = editVM.Country;
            user.ProfileImageUrl = photoResult.Url.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserProfileVM editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            var user = await _dashboardRepository.GetUserByIdNoTracking(editVM.Id); 

            if (string.IsNullOrEmpty(user.ProfileImageUrl))
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);

                return RedirectToAction("Index", "Dashboard");
            }
        
        }
    }
}
