﻿using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.DTOs.Shared;
using System.Threading.Tasks;
using SmartGarage.Service.DTOs.GetDTOs;

namespace SmartGarage.Service.Contracts
{
    public interface IManufacturerService
    {
        Task<GetManufacturerDTO> CreateAsync(ManufacturerDTO manufacturerInformation);

        Task<bool> UpdateAsync(ManufacturerDTO updateInformation, int id);

        Task<GetManufacturerDTO> GetAsync(int id);

        Task<Pager<GetManufacturerDTO>> GetAllAsync(PaginationQueryObject pagination);
    }
}
