using SmartGarage.Data.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class Vehicle : IIsDeletable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        public string VIN { get; set; }

        [Required]
        public string Colour { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public bool IsDeleted { get; set; }
    }
}