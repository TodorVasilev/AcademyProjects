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
        public string NumberPlate { get; set; }

        [Required]
        [StringLength(17)]
        public string VIN { get; set; }

        [Required]
        public string Colour { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public bool IsDeleted { get; set; }
    }
}