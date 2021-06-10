using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles types.
    /// </summary>
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly SmartGarageContext context;

        public VehicleTypeService(SmartGarageContext context)
        {
            this.context = context;
        }

        //Gets all vehicle types.
        public async Task<List<VehicleType>> GetAll()
        {
            return await context.VehicleTypes
                .ToListAsync();
        }
    }
}
