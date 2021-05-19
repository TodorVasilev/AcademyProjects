using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceHelpes;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    /// <summary>
    /// This class is responsible for CRUD operations performed on the services.
    /// </summary>
    public class ServiceService : IServiceService
    {
        public ServiceService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

        //Creates new service.
        public async Task<GetServiceDTO> CreateAsync(CreateServiceDTO serviceInformation)
        {
            var serviceToAdd = new Data.Models.Service
            {
                Name = serviceInformation.Name,
                Price = serviceInformation.Price
            };

            await Context.Services.AddAsync(serviceToAdd);
            await Context.SaveChangesAsync();

            return new GetServiceDTO(serviceToAdd);
        }

        //Deletes service with specific id using soft delete.
        public async Task<bool> RemoveAsync(int id)
        {
            var service = await Context.Services
               .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a service with this id or when is deleted.
            if (service == null || service.IsDeleted)
            {
                return false;
            }

            service.IsDeleted = true;

            Context.Update(service);
            await Context.SaveChangesAsync();

            return true;
        }

        //Gets all services possibly filtered by some creteria, based on some specified pagination information.
        public async Task<Pager<GetServiceDTO>> GetAllAsync(PaginationQueryObject pagination, ServiceFilterQueryObject filterObject)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicleModels = Context.Services
                .Where(s => !s.IsDeleted)
                .AsQueryable()
                .FilterServices(filterObject);

            //Returns null when there is not a service with this id.
            if (vehicleModels.Count() == 0)
            {
                return null;
            }

            var count = vehicleModels.Count();

            var vehicleModelsDTO = await vehicleModels.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetServiceDTO(x))
                .ToListAsync();

            Pager<GetServiceDTO> result = new Pager<GetServiceDTO>(vehicleModelsDTO, pagination)
            {
                Count = count
            };

            return result;
        }

        //Gets a service with specific id.
        public async Task<GetServiceDTO> GetAsync(int id)
        {
            var service = await Context.Services
               .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a service with this id or when is deleted.
            if (service == null || service.IsDeleted)
            {
                return null;
            }

            return new GetServiceDTO(service);
        }

        //Updates a service with specific id.
        public async Task<GetServiceDTO> UpdateAsync(UpdateServiceDTO updateInformation, int id)
        {
            var service = await Context.Services
             .FirstOrDefaultAsync(v => v.Id == id);

            //Returns null when there is not a service with this id or when is deleted.
            if (service == null || service.IsDeleted)
            {
                return null;
            }

            service.UpdateService(updateInformation);

            Context.Update(service);
            await Context.SaveChangesAsync();

            return new GetServiceDTO(service);
        }

        //Gets all services linked to customer, possibly filtered by some creteria, based on some specified pagination information.
        public async Task<Pager<GetServiceDTO>> GetAllLinkedToCustomerAsync(PaginationQueryObject pagination, CustomerServicesFilterQueryObject filterObject, User customer)
        {
            //The amount of items to skip
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var servicesOrders = Context.ServiceOrders
                .Include(so => so.Service)
                .Include(so => so.Order)
                .ThenInclude(o => o.Vehicle)
                .ThenInclude(v => v.User)
                .Where(so => so.Order.Vehicle.User.UserName == customer.UserName)
                .FilterCustomerServices(filterObject);

            //Returns null when there aren't any services linked to the customer.
            if (servicesOrders.Count() == 0)
            {
                return null;
            }

            var count = servicesOrders.Count();

            var vehicleModelsDTO = await servicesOrders.Skip(skipPages)
                .Take(pagination.ItemsOnPage)
                .Select(x => new GetServiceDTO(x.Service))
                .ToListAsync();

            Pager<GetServiceDTO> result = new Pager<GetServiceDTO>(vehicleModelsDTO, pagination)
            {
                Count = count
            };

            return result;
        }
    }
}
