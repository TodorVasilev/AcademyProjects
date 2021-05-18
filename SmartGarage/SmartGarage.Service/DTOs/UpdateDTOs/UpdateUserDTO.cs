using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.UpdateDTOs
{
    public class UpdateUserDTO
    {
     
        [MinLength(2), MaxLength(20)]
        [Display(Name = "User name")]
        public string UserName { get; set; }


        [MinLength(2), MaxLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

 
        [MinLength(2), MaxLength(20)]
        [Display(Name = "Family name")]
        public string LastName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


        [Range(18, 100)]
        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Driving license number")]
        public string DrivingLicenseNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

     
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
