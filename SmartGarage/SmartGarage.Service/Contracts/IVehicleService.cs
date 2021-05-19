using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IVehicleService
    {
        Task<bool> RemoveAsync(int id);

        Task<GetVehicleDTO> CreateAsync(CreateVehicleDTO vehicleInformation);

        Task<bool> UpdateAsync(UpdateVehicleDTO updateInformation, int id);

        Task<GetVehicleDTO> GetAsync(int id);

        Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name);
    }
}