using SmartGarage.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetVehicleDTO
    {
		public GetVehicleDTO()
		{

		}
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
            this.OwnerUserName = vehicle.User.UserName;
            this.Manufacturer = vehicle.VehicleModel.Manufacturer.Name;
        }

        [Required]
        public int Id { get; set; }

        public string OwnerUserName { get; set; }

        [JsonIgnore]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Owner { get; set; }

        [JsonIgnore]
        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "{0} must be between {1} and {2} symbols.")]
        public string NumberPlate { get; set; }

        [StringLength(17, ErrorMessage = "{0} must be exactly {1} symbols.")]
        [Required]
        public string VIN { get; set; }
    }
}
