using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class VehicleViewModel
    {
        [Required]
        public int UserId { get; }

        public string OwnerUserName { get; }

        [Required]
        public int VehicleModelId { get; }

        [Required]
        public string VehicleModel { get; }

        [Required]
        public int ManufacturerId { get; }

        [Required]
        public string Manufacturer { get; }

        [Required]
        public string Colour { get; }

        public IEnumerable<GetManufacturerDTO> Manufacturers { get; set; }

        public IEnumerable<GetVehicleModelDTO> Models { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; }

        [StringLength(17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        [Required]
        public string VIN { get; }
    }
}
