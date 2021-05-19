using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.Service.ServiceHelpes;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        public VehicleService(SmartGarageContext context)
        {
            this.Context = context;
        }

        public SmartGarageContext Context { get; }

        //Creates new vehicle.
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

        //Gets all vehicles possibly filtered by their name, based on some specified pagination information.
        public async Task<Pager<GetVehicleDTO>> GetAllAsync(PaginationQueryObject pagination, string name)
        {
            //The amount of items to skip
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicles = Context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Manufacturer)
                .Where(v => !v.IsDeleted)
                .AsQueryable();

            //Returns null when there aren't any vehicles..
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

        //Gets a vehicle with specific id.
        public async Task<GetVehicleDTO> GetAsync(int id)
        {
            var vehicle = await Context.Vehicles
               .Include(v => v.User)
               .Include(v => v.VehicleModel)
               .ThenInclude(vm => vm.Manufacturer)
               .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a vehicle with this id or when is deleted.
            if (vehicle == null || vehicle.IsDeleted)
            {
                return null;
            }

            return new GetVehicleDTO(vehicle);
        }

        //Deletes a vehicle with specific id using soft delete.
        public async Task<bool> RemoveAsync(int id)
        {
            var vehicle = await Context.Vehicles
              .Include(v => v.User)
              .Include(v => v.VehicleModel)
              .ThenInclude(vm => vm.Manufacturer)
              .FirstOrDefaultAsync(v => v.Id == id);

            //Returns false when there is not a vehicle with this id or when is deleted.
            if (vehicle == null || vehicle.IsDeleted)
            {
                return false;
            }

            vehicle.IsDeleted = true;

            Context.Update(vehicle);
            await Context.SaveChangesAsync();

            return true;
        }

        //Updates a vehicle with specific id.
        public async Task<bool> UpdateAsync(UpdateVehicleDTO updateInformation, int id)
        {
            var vehicle = await Context.Vehicles
              .Include(v => v.User)
              .Include(v => v.VehicleModel)
              .ThenInclude(vm => vm.Manufacturer)
              .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a vehicle with this id or when is deleted.
            if (vehicle == null || vehicle.IsDeleted)
            {
                return false;
            }

            return true;
        }
    }
}