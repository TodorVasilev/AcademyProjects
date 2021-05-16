﻿using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Helpers;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class VehicleService : IVehicleService
    {
        public VehicleService(SmartGarageContext context)
        {
            this.Context = context;
        }

        public SmartGarageContext Context { get; set; }

        public async Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicles = Context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                    .ThenInclude(vm => vm.Manufacturer)
                    .AsQueryable();

            if(name != default)
            {
                vehicles = vehicles.Where(v => v.User.UserName == name);
            }

            var count = vehicles.Count();

            var vehiclesDTO = await vehicles.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetVehicleDTO(x))
                .ToListAsync();

            Pager<GetVehicleDTO> result = new Pager<GetVehicleDTO>(vehiclesDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        public async Task<GetVehicleDTO> GetAsync(int id)
        {
            var vehicle = await Context.Vehicles
               .Include(v => v.User)
               .Include(v => v.VehicleModel)
                   .ThenInclude(vm => vm.Manufacturer)
               .FirstOrDefaultAsync(v => v.Id == id);

            return new GetVehicleDTO(vehicle);
        }
    }
}
