using Microsoft.EntityFrameworkCore.Query;
using SmartGarage.Data.Models;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using System.Collections.Generic;
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
                services = services.Where(s => s.Name.Contains(filterObject.Name));
            }
            if (filterObject.Price != default)
            {
                services = services.Where(s => s.Price == filterObject.Price);
            }

            return services;
        }

        public static Data.Models.Service UpdateService(this Data.Models.Service service, UpdateServiceDTO updateInformation)
        {
            if (updateInformation.Name != default)
            {
                service.Name = updateInformation.Name;
            }
            if (updateInformation.Price != default)
            {
                service.Price = updateInformation.Price;
            }

            return service;
        }
        public static IQueryable<ServiceOrder> FilterCustomerServices(this IQueryable<ServiceOrder> serviceOrders, CustomerServicesFilterQueryObject filterObject)
        {
            if (filterObject.VehicleId != default)
            {
                serviceOrders = serviceOrders.Where(so => so.Order.Vehicle.Id == filterObject.VehicleId);
            }
            if (filterObject.VisitDate != default)
            {
                serviceOrders = serviceOrders.Where(so => so.Order.ArrivalDate == filterObject.VisitDate);
            }

            return serviceOrders;
        }

        public static List<User> SortBy(this List<User> customerToOrder, string CustomerName, string OrderDate)
        {
            customerToOrder = (CustomerName, OrderDate) switch
            {
                ("asc", null) => customerToOrder.OrderBy(u => u.FirstName).ToList(),
                ("desc",null) => customerToOrder.OrderByDescending(u => u.FirstName).ToList(),
                (null, "asc") => customerToOrder.OrderBy(u => u.Vehicles.SelectMany(v => v.Orders.Select(o => o.ArrivalDate))).ToList(),
                (null, "desc") => customerToOrder.OrderByDescending(u => u.Vehicles.SelectMany(v => v.Orders.Select(o => o.ArrivalDate))).ToList(),
                _ => customerToOrder.OrderBy(u => u.FirstName).ToList()
            };
                return customerToOrder;
        }

    }
}
