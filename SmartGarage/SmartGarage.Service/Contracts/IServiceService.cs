using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IServiceService
    {
        Task<Pager<GetServiceDTO>> GetAllAsync(PaginationQueryObject pagination, ServiceFilterQueryObject filterObject);

        Task<GetServiceDTO> GetAsync(int id);
    }
}
