using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartGarage.Service.DTOs.GetDTOs
{
    public class GetVehicleModelDTO
    {
        public GetVehicleModelDTO(VehicleModel vehicleModel)
        {
            this.Id = vehicleModel.Id;
            this.Name = vehicleModel.Name;
            this.ManafacturerName = vehicleModel.Manufacturer.Name;
            this.VehicleType = vehicleModel.VehicleType.Name;
            this.ManufacturerId = vehicleModel.ManufacturerId;
            this.VehicleTypeId = vehicleModel.VehicleTypeId;
        }

        public int Id { get; }

        public string Name { get; }

        public string ManafacturerName { get; }

        [JsonIgnore]
        public int ManufacturerId { get; }

        [JsonIgnore]
        public int VehicleTypeId { get; }

        public string VehicleType { get; }
    }
}
