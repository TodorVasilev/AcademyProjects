using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartGarage.Service.DTOs.UpdateDTOs
{
    public class UpdateVehicleDTO
    {
        public int VehicleModelId { get; }

        public int UserId { get; }

        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; }

        [StringLength(17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        public string VIN { get; }

        public string Colour { get; }
    }
}
