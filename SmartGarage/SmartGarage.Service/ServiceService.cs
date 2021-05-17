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

namespace SmartGarage.Service
{
    public class ServiceService : IServiceService
    {
        public ServiceService(SmartGarageContext context)
        {
            Context = context;
        }

        public SmartGarageContext Context { get; }

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
