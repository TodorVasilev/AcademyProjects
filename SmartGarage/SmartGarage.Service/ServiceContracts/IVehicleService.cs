﻿using SmartGarage.Data.Helpers;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    interface IVehicleService
    {
        Task<GetVehicleDTO> Update(UpdateVehicleDTO update, int id);

        Task<GetVehicleDTO> GetAsync(int id);

        Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name);
    }
}
