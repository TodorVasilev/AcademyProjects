using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Helpers;
using SmartGarage.Data.Models;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.Service.ServiceHelpes;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles.
    /// </summary>
    /// <seealso cref="SmartGarage.Service.ServiceContracts.IVehicleService" />
    public class Service : IVehicleService
    {
        public Service(SmartGarageContext context)
        {
            this.Context = context;
        }

        public SmartGarageContext Context { get; }

        public async Task<GetVehicleDTO> CreateAsync(CreateVehicleDTO vehicleInformation)
        {
            var vehicleToAdd = new Vehicle
            {
                UserId = vehicleInformation.UserId,
                VehicleModelId = vehicleInformation.VehicleModelId,
                NumberPlate = vehicleInformation.NumberPlate,
                VIN = vehicleInformation.VIN,
                Colour = vehicleInformation.Colour
            };

            await Context.Vehicles.AddAsync(vehicleToAdd);
            await Context.SaveChangesAsync();

            var vehicle = await Context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Manufacturer)
                .FirstOrDefaultAsync(v => v.Id == vehicleToAdd.Id);

            return new GetVehicleDTO(vehicle);
        }

        public async Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicles = Context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Manufacturer)
                .Where(v => !v.IsDeleted)
                .AsQueryable();

            if (vehicles.Count() == 0)
            {
                return null;
            }

            if (name != default)
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
               .Where(v => !v.IsDeleted)
               .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return null;
            }

            return new GetVehicleDTO(vehicle);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var vehicle = await Context.Vehicles
              .Include(v => v.User)
              .Include(v => v.VehicleModel)
              .ThenInclude(vm => vm.Manufacturer)
              .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDeleted = true;

            Context.Update(vehicle);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<GetVehicleDTO> UpdateAsync(UpdateVehicleDTO updateInformation, int id)
        {
            var vehicle = await Context.Vehicles
              .Include(v => v.User)
              .Include(v => v.VehicleModel)
              .ThenInclude(vm => vm.Manufacturer)
              .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return null;
            }

            vehicle.UpdateVehicle(updateInformation);

            Context.Update(vehicle);
            await Context.SaveChangesAsync();

            return new GetVehicleDTO(vehicle);
        }
    }
}