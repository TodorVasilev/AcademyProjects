using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        [Display(Name = "Garage name")]
        public string GarageName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        [Display(Name = "Family name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[0]{1}\d{9}", ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        [Display(Name = "Driving license number")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        public string VIN { get; set; }

        [Required]
        public string Colour { get; set; }

        public IEnumerable<GetManufacturerDTO> Manufacturers { get; set; }

        [Required]
        public int ManufacturerId { get; set; }


        public IEnumerable<GetVehicleModelDTO> Models { get; set; }

        [Required]
        public int VehicleModelId { get; set; }


    }
}
