using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class VehicleEditViewModel
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public int UserId { get; set; }

        public string Colour { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string NumberPlate { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        public string VIN { get; set; }
    }
}