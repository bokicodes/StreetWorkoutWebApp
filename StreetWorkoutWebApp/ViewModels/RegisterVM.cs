using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutWebApp.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20,MinimumLength = 6, ErrorMessage = "Password must have between 6 and 20 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "" +
            "Password must contain an uppercase character, lowercase character, a digit, and a non-alphanumeric character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password",ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
