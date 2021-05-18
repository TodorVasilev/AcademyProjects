using SmartGarage.Data.Models;

namespace SmartGarage.Service.DTOs.Shared
{
    public class ManufacturerDTO
    {
        public ManufacturerDTO(Manufacturer manufacturer)
        {
            this.Name = manufacturer.Name;
        }

        public string Name { get; set; }
    }
}
