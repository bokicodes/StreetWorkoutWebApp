using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutWebApp.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
