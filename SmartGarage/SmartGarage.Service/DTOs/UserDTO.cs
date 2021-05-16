using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartGarage.Service.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.PhoneNumber = user.PhoneNumber;
            this.Age = user.Age;
            this.DrivingLicenseNumber = user.DrivingLicenseNumber;
            this.Address = user.Address;

        }
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        public string Address { get; set; }


    }
}
