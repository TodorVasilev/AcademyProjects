using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Data.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}