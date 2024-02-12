using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Models;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            AppUser user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                bool passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Park");
                    }
                    else
                    {
                        TempData["Error"] = "Sign in failed.";
                        return View(loginVM);
                    }
                }
                else
                {
                    TempData["Error"] = "Wrong password. Please, try again.";
                    return View(loginVM);
                }
            }
            else
            {
                TempData["Error"] = "Wrong credentials. Please, try again.";
                return View(loginVM);
            }
        }

    }
}
