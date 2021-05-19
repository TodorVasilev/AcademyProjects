using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.Service.ServiceHelpes;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles models.
    /// </summary>
    public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

        //Creates new vehicle model.
        public async Task<GetVehicleModelDTO> CreateAsync(VehicleModelDTO vehicleModelInformation)
        {
            var vehicleModelToAdd = new VehicleModel
            {
                Name = vehicleModelInformation.Name,
                VehicleTypeId = vehicleModelInformation.VehicleTypeId,
                ManufacturerId = vehicleModelInformation.ManufacturerId
            };

            await Context.VehicleModels.AddAsync(vehicleModelToAdd);
            await Context.SaveChangesAsync();

            var vehicleModel = await Context.VehicleModels
               .Include(vm => vm.Manufacturer)
               .Include(vm => vm.VehicleType)
               .FirstOrDefaultAsync(mv => mv.Id == vehicleModelToAdd.Id);

            return new GetVehicleModelDTO(vehicleModel);
        }

        //Gets all vehicle models, based on some specified pagination information.
        public async Task<Pager<GetVehicleModelDTO>> GetAllAsync(PaginationQueryObject pagination)
        {
            //The amount of items to skip
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicleModels = Context.VehicleModels
                .Include(vm => vm.Manufacturer)
                .Include(vm => vm.VehicleType)
                .AsQueryable();

            //Returns null when there aren't any vehicle models.
            if (vehicleModels.Count() == 0)
            {
                return null;
            }

            var count = vehicleModels.Count();

            var vehicleModelsDTO = await vehicleModels.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetVehicleModelDTO(x))
                .ToListAsync();

            Pager<GetVehicleModelDTO> result = new Pager<GetVehicleModelDTO>(vehicleModelsDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        //Gets a vehicle model with specific id.
        public async Task<GetVehicleModelDTO> GetAsync(int id)
        {
            var vehicleModels = await Context.VehicleModels
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
            var vehicleModel = await Context.VehicleModels
             .Include(vm => vm.Manufacturer)
             .Include(vm => vm.VehicleType)
             .FirstOrDefaultAsync(v => v.Id == id);


            //Returns null when there is not a vehicle model with this id.
            if (vehicleModel == null)
            {
                return false;
            }

            vehicleModel.UpdateVehicleModel(updateInformation);

            Context.Update(vehicleModel);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}
