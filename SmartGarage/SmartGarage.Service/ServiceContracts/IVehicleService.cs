using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    interface IVehicleService
    {
        Task<GetVehicleDTO> GetAsync(int id);

        Task<List<GetVehicleDTO>> GetAllAsync(string name);
    }
}
