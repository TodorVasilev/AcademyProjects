using SmartGarage.Data.Models;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateVehicleModelDTO
    {
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public int VehicleTypeId { get; set; }
    }
}
