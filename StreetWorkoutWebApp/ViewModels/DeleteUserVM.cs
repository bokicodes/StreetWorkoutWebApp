namespace StreetWorkoutWebApp.ViewModels
{
    public class DeleteUserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
