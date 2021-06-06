using SmartGarage.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateUserDTO
    {
        public CreateUserDTO()
        {

        }
        public CreateUserDTO(User user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.PhoneNumber = user.PhoneNumber;
            this.Age = user.Age;
            this.DrivingLicenseNumber = user.DrivingLicenseNumber;
            this.Address = user.Address;
            this.Email = user.Email;
        }

        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "Family name:")]
        public string LastName { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number:")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18, 100)]
        [Display(Name = "Age:")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Driving license number:")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }
    }
}

