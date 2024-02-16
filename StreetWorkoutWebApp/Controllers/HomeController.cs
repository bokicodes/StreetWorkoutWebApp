using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreetWorkoutWebApp.Helpers;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;
using StreetWorkoutWebApp.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace StreetWorkoutWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IParkRepository _parkRepository;

        public HomeController(ILogger<HomeController> logger, IParkRepository parkRepository)
        {
            _logger = logger;
            _parkRepository = parkRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeVM = new HomeVM();

            try
            {
                string url = "https://ipinfo.io?token=b8b105f3439add";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI.EnglishName;
                homeVM.City = ipInfo.City;
                homeVM.Country = ipInfo.Country;

                if(homeVM.City != null)
                {
                    homeVM.Parks = await _parkRepository.GetParksByCity(homeVM.City);
                }
                else
                {
                    homeVM.Parks = null;
                }

                return View(homeVM);
            }
            catch (Exception)
            {
                homeVM.Parks = null;

            }

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}