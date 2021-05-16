using SmartGarage.Data.Helpers;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    public interface IVehicleModelService
    {
        Task<Pager<GetVehicleModelDTO>> GetAllAsync(PaginationQueryObject pagination);

        Task<GetVehicleModelDTO> GetAsync(int id);
    }
}