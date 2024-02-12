﻿using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutWebApp.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password",ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}