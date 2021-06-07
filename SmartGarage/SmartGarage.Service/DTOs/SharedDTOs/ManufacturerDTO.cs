using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Service.DTOs.Shared
{
    public class ManufacturerDTO
    {
        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Name { get; set; }
    }
}
