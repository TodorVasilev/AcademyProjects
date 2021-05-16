using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Helpers;
using SmartGarage.Data.Models;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.Service.ServiceHelpes;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public VehicleModelService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

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

        public async Task<Pager<GetVehicleModelDTO>> GetAllAsync(PaginationQueryObject pagination)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicleModels = Context.VehicleModels
                .Include(vm => vm.Manufacturer)
                .Include(vm => vm.VehicleType)
                .AsQueryable();

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

        public async Task<GetVehicleModelDTO> GetAsync(int id)
        {
            var vehicleModels = await Context.VehicleModels
               .Include(vm => vm.Manufacturer)
               .Include(vm => vm.VehicleType)
               .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleModels == null)
            {
                return null;
            }

            return new GetVehicleModelDTO(vehicleModels);
        }

        public async Task<GetVehicleModelDTO> UpdateAsync(VehicleModelDTO updateInformation, int id)
        {
            var vehicleModel = await Context.VehicleModels
             .Include(vm => vm.Manufacturer)
             .Include(vm => vm.VehicleType)
             .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleModel == null)
            {
                return null;
            }
            
            vehicleModel.UpdateVehicleModel(updateInformation);

            Context.Update(vehicleModel);
            await Context.SaveChangesAsync();

            return new GetVehicleModelDTO(vehicleModel);
        }
    }
}
