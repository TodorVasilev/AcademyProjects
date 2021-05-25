using SmartGarage.Data.Models;
using System.Collections.Generic;
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

        public string Name { get; }

        [JsonIgnore]
        public List<VehicleModel> Models { get; }
    }
}
