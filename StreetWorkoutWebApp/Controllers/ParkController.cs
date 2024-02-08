using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;
using StreetWorkoutWebApp.ViewModels;

namespace StreetWorkoutWebApp.Controllers
{
    public class ParkController : Controller
    {
        private readonly IParkRepository _parkRepository;
        private readonly IPhotoService _photoService;

        public ParkController(IParkRepository parkRepository, IPhotoService photoService)
        {
            _parkRepository = parkRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Park> parks = await _parkRepository.GetAll(); 
            return View(parks);
        }

        public async Task<IActionResult> Details(int id)
        {
            Park park = await _parkRepository.GetByIdAsync(id);
            return View(park);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateParkVM parkVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(parkVM.Image);

                var park = new Park
                {
                    Title = parkVM.Title,
                    Description = parkVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = parkVM.Address.Street,
                        City = parkVM.Address.City,
                        Country = parkVM.Address.City
                    }
                };
                _parkRepository.Add(park);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(parkVM);
        }
    }
}
