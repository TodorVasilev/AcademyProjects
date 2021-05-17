using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using System.Linq;

namespace SmartGarage.Service.ServiceHelpes
{
    public static class ExtentionsMethods
    {
        public static Vehicle UpdateVehicle(this Vehicle vehicle, UpdateVehicleDTO update)
        {
            if (update.Colour != default)
            {
                vehicle.Colour = update.Colour;
            }
            if (update.NumberPlate != default)
            {
                vehicle.NumberPlate = update.NumberPlate;
            }
            if (update.UserId != default)
            {
                vehicle.UserId = update.UserId;
            }
            if (update.VIN != default)
            {
                vehicle.VIN = update.VIN;
            }
            if (update.VehicleModelId != default)
            {
                vehicle.VehicleModelId = update.VehicleModelId;
            }

            return vehicle;
        }

        public static VehicleModel UpdateVehicleModel(this VehicleModel vehicleModel, VehicleModelDTO update)
        {
            if (update.Name != default)
            {
                vehicleModel.Name = update.Name;
            }
            if (update.ManufacturerId != default)
            {
                vehicleModel.ManufacturerId = update.ManufacturerId;
            }
            if (update.VehicleTypeId != default)
            {
                vehicleModel.VehicleTypeId = update.VehicleTypeId;
            }

            return vehicleModel;
        }

        public static IQueryable<Data.Models.Service> FilterServices(this IQueryable<Data.Models.Service> services, ServiceFilterQueryObject filterObject)
        {
            if (filterObject.Name != default)
            {
                services = services.Where(s => s.Name == filterObject.Name);
            }
            if (filterObject.Price != default)
            {
                services = services.Where(s => s.Price == filterObject.Price);
            }

            return services;
        }
    }
}
