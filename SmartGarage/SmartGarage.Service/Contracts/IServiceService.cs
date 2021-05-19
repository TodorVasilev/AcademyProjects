using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IServiceService
    {
        Task<Pager<GetServiceDTO>> GetAllAsync(PaginationQueryObject pagination, ServiceFilterQueryObject filterObject);

        Task<GetServiceDTO> GetAsync(int id);

        Task<GetServiceDTO> CreateAsync(CreateServiceDTO serviceInformation);

        Task<bool> UpdateAsync(UpdateServiceDTO updateInformation, int id);

        Task<Pager<GetServiceDTO>> GetAllLinkedToCustomerAsync(PaginationQueryObject pagination, CustomerServicesFilterQueryObject filterObject, int userId);

        Task<bool> RemoveAsync(int id);
    }
}
