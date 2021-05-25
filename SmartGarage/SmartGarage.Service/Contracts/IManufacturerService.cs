using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IManufacturerService
    {
        Task<GetManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation);

        Task<bool> UpdateAsync(ManufacturerDTO updateInformation, int id);

        Task<GetManufacturerDTO> GetAsync(int id);

        Task<List<GetManufacturerDTO>> GetAll();
    }
}
