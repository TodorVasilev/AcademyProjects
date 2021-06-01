using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly SmartGarageContext context;

        public VehicleTypeService(SmartGarageContext context)
        {
            this.context = context;
        }

        //Gets all vehicle types, based on some specified pagination information.
        public async Task<List<VehicleType>> GetAll()
        {
            return await context.VehicleTypes
                .ToListAsync();
        }
    }
}
