using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGarage.ViewModels
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public IEnumerable<GetManufacturerDTO> Manufacturers { get; set; }

        public int VehicleTypeId { get; set; }

        public IEnumerable<VehicleType> VehicleTypes { get; set; }
    }
}
