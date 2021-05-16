using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
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

        public async Task<List<GetVehicleDTO>> GetAllAsync(string name)
        {
            var vehicles = Context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                    .ThenInclude(vm => vm.Manufacturer)
                    .AsQueryable();

            var vehiclesDTO = new List<GetVehicleDTO>();

            foreach (var vehicle in vehicles)
            {
                vehiclesDTO.Add(new GetVehicleDTO(vehicle));
            }

            return vehiclesDTO;
        }

        public async Task<GetVehicleDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
