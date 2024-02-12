using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutWebApp.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
