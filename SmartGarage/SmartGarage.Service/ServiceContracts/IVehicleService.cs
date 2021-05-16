using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    interface IVehicleService
    {
        Task<GetVehicleDTO> GetAsync(int id);

        Task<List<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name);
    }
}
