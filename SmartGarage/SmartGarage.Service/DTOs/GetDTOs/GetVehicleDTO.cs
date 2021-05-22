using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetVehicleDTO
    {
        public GetVehicleDTO(Vehicle vehicle)
        {
            this.Id = vehicle.Id;
            this.Owner = $"{vehicle.User.FirstName} {vehicle.User.LastName}";
            this.VehicleModel = vehicle.VehicleModel.Name;
            this.NumberPlate = vehicle.NumberPlate;
            this.VIN = vehicle.VIN;
            this.Colour = vehicle.Colour;
            this.VehicleModelId = vehicle.Id;
            this.UserId = vehicle.UserId;
        }

        [Required]
        public int Id { get; }

        [JsonIgnore]
        [Required]
        public int UserId { get; }

        [Required]
        public string Owner { get; }

        [JsonIgnore]
        [Required]
        public int VehicleModelId { get; }

        [Required]
        public string VehicleModel { get; }

        [Required]
        public string Colour { get; }

        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; }

        [StringLength(17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        [Required]
        public string VIN { get; }
    }
}
