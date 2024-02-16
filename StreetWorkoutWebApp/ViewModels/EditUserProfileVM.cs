namespace StreetWorkoutWebApp.ViewModels
{
    public class EditUserProfileVM
    {
        public string Id { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public IFormFile Image { get; set; }
    }
}
