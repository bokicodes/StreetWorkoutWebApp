using StreetWorkoutWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetWorkoutWebApp.ViewModels
{
    public class CreateParkVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
    }
}
