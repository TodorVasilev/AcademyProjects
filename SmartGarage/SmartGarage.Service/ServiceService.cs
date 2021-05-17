using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Threading.Tasks;
using System;
using SmartGarage.Data;
using System.Linq;
using SmartGarage.Service.ServiceHelpes;
using Microsoft.EntityFrameworkCore;
using SmartGarage.Service.DTOs.CreateDTOs;

namespace SmartGarage.Service
{
    public class ServiceService : IServiceService
    {
        public ServiceService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

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

        public async Task<bool> RemoveAsync(int id)
        {
            var service = await Context.Services
               .FirstOrDefaultAsync(v => v.Id == id);

            if (service == null)
            {
                return false;
            }

            service.IsDeleted = true;

            Context.Update(service);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<Pager<GetServiceDTO>> GetAllAsync(PaginationQueryObject pagination, ServiceFilterQueryObject filterObject)
        {
            var skipPages = (pagination.Page - 1) * pagination.ItemsOnPage;

            var vehicleModels = Context.Services
                .AsQueryable()
                .FilterServices(filterObject);

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

        public async Task<GetServiceDTO> GetAsync(int id)
        {
            var vehicleModels = await Context.Services
               .FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleModels == null)
            {
                return null;
            }

            return new GetServiceDTO(vehicleModels);
        }
    }
}
