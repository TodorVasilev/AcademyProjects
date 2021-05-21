using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.Service.ServiceHelpes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles models.
    /// </summary>
    public class VehicleModelService : IVehicleModelService
    {
        private readonly SmartGarageContext context;

        public VehicleModelService(SmartGarageContext context)
        {
            this.context = context;
        }

        //Creates new vehicle model.
        public async Task<GetVehicleModelDTO> CreateAsync(VehicleModelDTO vehicleModelInformation)
        {
            var vehicleModelToAdd = new VehicleModel
            {
                Name = vehicleModelInformation.Name,
                VehicleTypeId = vehicleModelInformation.VehicleTypeId,
                ManufacturerId = vehicleModelInformation.ManufacturerId
            };

            await context.VehicleModels.AddAsync(vehicleModelToAdd);
            await context.SaveChangesAsync();

            var vehicleModel = await context.VehicleModels
               .Include(vm => vm.Manufacturer)
               .Include(vm => vm.VehicleType)
               .FirstOrDefaultAsync(mv => mv.Id == vehicleModelToAdd.Id);

            return new GetVehicleModelDTO(vehicleModel);
        }

        //Gets all vehicle models, based on some specified pagination information.
        public async Task<List<GetVehicleModelDTO>> GetAll()
        {
            var vehicleModels = context.VehicleModels
                .Include(vm => vm.Manufacturer)
                .Include(vm => vm.VehicleType)
                .AsQueryable();

            if (vehicleModels.Count() == 0)
            {
                return null;
            }

            return await vehicleModels.Select(x => new GetVehicleModelDTO(x))
                .ToListAsync();
        }

        //Gets a vehicle model with specific id.
        public async Task<GetVehicleModelDTO> GetAsync(int id)
        {
            var vehicleModels = await context.VehicleModels
               .Include(vm => vm.Manufacturer)
               .Include(vm => vm.VehicleType)
               .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a vehicle model with this id.
            if (vehicleModels == null)
            {
                return null;
            }

            return new GetVehicleModelDTO(vehicleModels);
        }

        //Updates a vehicle model with specific id.
        public async Task<bool> UpdateAsync(VehicleModelDTO updateInformation, int id)
        {
            var vehicleModel = await context.VehicleModels
             .Include(vm => vm.Manufacturer)
             .Include(vm => vm.VehicleType)
             .FirstOrDefaultAsync(v => v.Id == id);


            //Returns null when there is not a vehicle model with this id.
            if (vehicleModel == null)
            {
                return false;
            }

            vehicleModel.UpdateVehicleModel(updateInformation);

            context.Update(vehicleModel);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
