﻿using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.ServiceHelpes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the vehicles.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private readonly SmartGarageContext context;

        public VehicleService(SmartGarageContext context)
        {
            this.context = context;
        }

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

            await context.Vehicles.AddAsync(vehicleToAdd);
            await context.SaveChangesAsync();

            var vehicle = await context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Manufacturer)
                .FirstOrDefaultAsync(v => v.Id == vehicleToAdd.Id);

            return new GetVehicleDTO(vehicle);
        }

        //Gets all vehicles possibly filtered by their name.
        public async Task<List<GetVehicleDTO>> GetAll(string name)
        {
            var vehicles = context.Vehicles
                .Include(v => v.User)
                .Include(v => v.VehicleModel)
                .ThenInclude(vm => vm.Manufacturer)
                .Where(v => !v.IsDeleted);

            //Returns null when there aren't any vehicles..
            if (vehicles.Count() == 0)
            {
                return null;
            }

            if (name != default)
            {
                vehicles = vehicles.Where(v => v.User.UserName.Contains(name));
            }

            return await vehicles.Select(x => new GetVehicleDTO(x))
                .ToListAsync();
        }

        //Gets a vehicle with specific id.
        public async Task<GetVehicleDTO> GetAsync(int id)
        {
            var vehicle = await context.Vehicles
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
            var vehicle = await context.Vehicles
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

            context.Update(vehicle);
            await context.SaveChangesAsync();

            return true;
        }

        //Updates a vehicle with specific id.
        public async Task<bool> UpdateAsync(UpdateVehicleDTO updateInformation, int id)
        {
            var vehicle = await context.Vehicles
              .Include(v => v.User)
              .Include(v => v.VehicleModel)
              .ThenInclude(vm => vm.Manufacturer)
              .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a vehicle with this id or when is deleted.
            if (vehicle == null || vehicle.IsDeleted)
            {
                return false;
            }

            vehicle.UpdateVehicle(updateInformation);

            context.Update(vehicle);
            await context.SaveChangesAsync();

            return true;
        }
    }
}