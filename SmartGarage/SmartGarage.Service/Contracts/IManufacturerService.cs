using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.DTOs.Shared;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IManufacturerService
    {
        Task<ManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation);

        Task<ManufacturerDTO> UpdateAsync(ManufacturerDTO updateInformation, int id);

        Task<ManufacturerDTO> GetAsync(int id);

        Task<Pager<ManufacturerDTO>> GetAllAsync(PaginationQueryObject pagination);
    }
}
