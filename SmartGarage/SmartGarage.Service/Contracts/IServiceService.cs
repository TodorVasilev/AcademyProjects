using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IServiceService
    {
        Task<List<GetServiceDTO>> GetAll(ServiceFilterQueryObject filterObject);

        Task<GetServiceDTO> GetAsync(int id);

        Task<GetServiceDTO> CreateAsync(CreateServiceDTO serviceInformation);

        Task<bool> UpdateAsync(UpdateServiceDTO updateInformation, int id);

        Task<List<GetServiceDTO>> GetAllLinkedToCustomer(CustomerServicesFilterQueryObject filterObject, int userId);

        Task<bool> RemoveAsync(int id);
        Task<List<GetServiceDTO>> GetAvailableServices(int orderID);

    }
}
