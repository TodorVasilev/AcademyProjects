using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string OwnerUserName { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Colour { get; set; }

        public IEnumerable<GetManufacturerDTO> Manufacturers { get; set; }

        public IEnumerable<GetVehicleModelDTO> Models { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string NumberPlate { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        [Required]
        public string VIN { get; set; }
    }
}
