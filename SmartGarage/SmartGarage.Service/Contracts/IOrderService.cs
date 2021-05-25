using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IOrderService
    {
        Task<bool> CreateAsync(CreateOrderDTO order);
        Task<bool> DeleteAsync(int id);
        Task<List<GetOrderDTO>> GetAll();
        Task<GetOrderDTO> GetAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder);
    }
}
