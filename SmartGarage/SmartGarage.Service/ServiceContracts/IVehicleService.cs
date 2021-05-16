using SmartGarage.Data.Helpers;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    interface IVehicleService
    {
        Task<bool> RemoveAsync(int id);

        Task<GetVehicleDTO> CreateAsync(CreateVehicleDTO vehicleInformation);

        Task<GetVehicleDTO> UpdateAsync(UpdateVehicleDTO updateInformation, int id);

        Task<GetVehicleDTO> GetAsync(int id);

        Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name);
    }
}