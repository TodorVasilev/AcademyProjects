using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public int Id { get; }

        public string Name { get; }

        public string ManafacturerName { get; }

        public string VehicleType { get; }
    }
}
