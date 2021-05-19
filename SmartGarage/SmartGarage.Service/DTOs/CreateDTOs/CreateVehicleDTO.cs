using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateVehicleDTO
    {
        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        public string VIN { get; set; }

        [Required]
        public string Colour { get; set; }
    }
}
