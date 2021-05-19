using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    public interface IVehicleModelService
    {
        Task<Pager<GetVehicleModelDTO>> GetAllAsync(PaginationQueryObject pagination);

        Task<GetVehicleModelDTO> GetAsync(int id);

        Task<GetVehicleModelDTO> CreateAsync(VehicleModelDTO vehicleModelInformation);

        Task<bool> UpdateAsync(VehicleModelDTO updateInformation, int id);
    }
}