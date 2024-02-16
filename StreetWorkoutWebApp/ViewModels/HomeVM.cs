using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.ViewModels
{
    public class HomeVM
    {
        public string City { get; set; }
        public string Country { get; set; }
        public IEnumerable<Park> Parks { get; set; }
    }
}
