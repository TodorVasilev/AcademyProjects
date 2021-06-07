using SmartGarage.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetManufacturerDTO
    {
        public GetManufacturerDTO(Manufacturer manufacturer)
        {
            this.Id = manufacturer.Id;
            this.Name = manufacturer.Name;
            this.Models = manufacturer.Models;
        }

        public int Id { get; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} symbols.")]
        public string Name { get; }

        [JsonIgnore]
        public List<VehicleModel> Models { get; }
    }
}
