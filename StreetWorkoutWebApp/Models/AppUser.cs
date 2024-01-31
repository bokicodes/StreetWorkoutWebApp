namespace StreetWorkoutWebApp.Models
{
    public class AppUser
    {
        public Address? Address { get; set; }
        public ICollection<Park> Parks { get; set; }
    }
}
