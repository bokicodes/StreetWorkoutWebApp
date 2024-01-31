using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutWebApp.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public Address? Address { get; set; }
        public ICollection<Park> Parks { get; set; }
    }
}
