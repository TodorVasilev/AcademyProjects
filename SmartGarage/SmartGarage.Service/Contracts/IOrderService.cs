using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IOrderService
    {
        Task<List<GetOrderDTO>> GetAll();
        Task<GetOrderDTO> GetAsync(int id);
    }
}
