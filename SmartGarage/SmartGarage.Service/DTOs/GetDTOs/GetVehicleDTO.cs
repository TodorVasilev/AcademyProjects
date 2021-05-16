using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetVehicleDTO
    {
        public GetVehicleDTO(Vehicle vehicle)
        {
            this.Id = vehicle.Id;
            this.VehicleModelId = vehicle.VehicleModelId;
            this.UserId = vehicle.UserId;
            this.NumberPlate = vehicle.NumberPlate;
            this.VIN = vehicle.VIN;
            this.Colour = vehicle.Colour;
        }

        [Required]
        public int Id { get; }

        [Required]
        public int VehicleModelId { get; }

        [Required]
        public int UserId { get; }

        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; }

        [StringLength(17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        [Required]
        public string VIN { get; }

        [Required]
        public string Colour { get; }
    }
}
