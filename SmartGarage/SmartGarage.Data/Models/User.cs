using Microsoft.AspNetCore.Identity;
using SmartGarage.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class User : IdentityUser<int>, IIsDeletable
    {
        [Required]
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }

        public string CurrentRole { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
