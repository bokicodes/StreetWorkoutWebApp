﻿using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.ViewModels
{
    public class EditParkVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public string? Url { get; set; }
    }
}
