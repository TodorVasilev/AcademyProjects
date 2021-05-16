using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.UpdateDTOs;

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
    }
}
