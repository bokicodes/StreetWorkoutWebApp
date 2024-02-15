using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                UserName = user.UserName
            };

            return View(userDetailVM);
        }
    }
}
