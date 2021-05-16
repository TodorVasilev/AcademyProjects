
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Helpers;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.ServiceContracts;

namespace SmartGarage.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

        public async Task<Pager<GetVehicleModelDTO>> GetAllAsync(PaginationQueryObject pagination)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicles = Context.VehicleModels
                .Include(vm => vm.Manufacturer)
                .Include(vm => vm.VehicleType)
                .AsQueryable();

            if (vehicles.Count() == 0)
            {
                return null;
            }

            var count = vehicles.Count();

            var vehicleModelsDTO = await vehicles.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetVehicleModelDTO(x))
                .ToListAsync();

            Pager<GetVehicleModelDTO> result = new Pager<GetVehicleModelDTO>(vehicleModelsDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        public async Task<GetVehicleModelDTO> GetAsync(int id)
        {
            var vehicle = await Context.VehicleModels
               .Include(vm => vm.Manufacturer)
               .Include(vm => vm.VehicleType)             
               .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return null;
            }

            return new GetVehicleModelDTO(vehicle);
        }
    }
}
