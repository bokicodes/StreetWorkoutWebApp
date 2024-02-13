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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ParkController(IParkRepository parkRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _parkRepository = parkRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var currUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createParkVM = new CreateParkVM
            {
                AppUserId = currUserId,
            };
            return View(createParkVM);
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
                    AppUserId = parkVM.AppUserId,
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

        public async Task<IActionResult> Edit(int id)
        {
            var park = await _parkRepository.GetByIdAsync(id);

            if(park == null)
            {
                return View("Error");
            }

            var parkVM = new EditParkVM
            {
                Title = park.Title,
                Description = park.Description,
                AddressId = park.AddressId,
                Address = park.Address,
                Url = park.Image
            };
            return View(parkVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditParkVM parkVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit park");
                return View("Edit", parkVM);
            }

            var park = await _parkRepository.GetByIdAsyncNoTracking(id);

            if (park != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(park.Image);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View("Edit", parkVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(parkVM.Image);

                var newPark = new Park
                {
                    Id = id,
                    Title = parkVM.Title,
                    Description = parkVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = parkVM.AddressId,
                    Address = parkVM.Address
                };

                _parkRepository.Update(newPark);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", parkVM);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var park = await _parkRepository.GetByIdAsync(id);

            if (park == null)
                return View("Error");

            return View(park);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeletePark(int id)
        {
            var park = await _parkRepository.GetByIdAsync(id);

            if (park == null)
                return View("Error");

            try
                {
                    await _photoService.DeletePhotoAsync(park.Image);
                }
            catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                }

            _parkRepository.Delete(park);
            return RedirectToAction("Index");
        }
    }
}
