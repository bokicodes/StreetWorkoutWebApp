using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Repository;
using StreetWorkoutWebApp.Services;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhotoService _photoService;

        public UserController(IUserRepository userRepository, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _photoService = photoService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            List<UserVM> usersVM = new List<UserVM>();

            foreach (var user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    ProfileImageUrl = user.ProfileImageUrl
                };
                usersVM.Add(userVM);
            }

            return View(usersVM);
        }


        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);

            var userDetailVM = new UserDetailVM
            {
                Id = user.Id,
                UserName = user.UserName,
                EmailAddress = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                Country = user.Country
            };

            return View(userDetailVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return View("Error");

            var userVM = new DeleteUserVM
            {
                Id = user.Id,
                City = user.City,
                Country = user.Country,
                EmailAddress = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                UserName = user.UserName
            };

            return View(userVM);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return View("Error");

            try
            {
                await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete photo");
            }

            _userRepository.Delete(user);
            return RedirectToAction("Index");
        }
    }
}
