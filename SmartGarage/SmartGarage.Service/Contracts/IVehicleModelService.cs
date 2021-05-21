using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    public interface IVehicleModelService
    {
        Task<GetVehicleModelDTO> GetAsync(int id);

        Task<GetVehicleModelDTO> CreateAsync(VehicleModelDTO vehicleModelInformation);

        Task<bool> UpdateAsync(VehicleModelDTO updateInformation, int id);

        Task<List<GetVehicleModelDTO>> GetAll();
    }
}