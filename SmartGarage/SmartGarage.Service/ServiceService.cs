using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceHelpes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
	/// <summary>
	/// This class is responsible for CRUD operations performed on the services.
	/// </summary>
	public class ServiceService : IServiceService
	{
		private readonly SmartGarageContext context;

		public ServiceService(SmartGarageContext context)
		{
			this.context = context;
		}

		//Creates new service.
		public async Task<GetServiceDTO> CreateAsync(CreateServiceDTO serviceInformation)
		{
			var serviceToAdd = new Data.Models.Service
			{
				Name = serviceInformation.Name,
				Price = (decimal)serviceInformation.Price
			};

			await context.Services.AddAsync(serviceToAdd);
			await context.SaveChangesAsync();

			return new GetServiceDTO(serviceToAdd);
		}

		//Deletes service with specific id using soft delete.
		public async Task<bool> RemoveAsync(int id)
		{
			var service = await context.Services
			   .FirstOrDefaultAsync(v => v.Id == id);

			//Returns null when there is not a service with this id or when is deleted.
			if (service == null || service.IsDeleted)
			{
				return false;
			}

			service.IsDeleted = true;

			context.Update(service);
			await context.SaveChangesAsync();

			return true;
		}

		//Gets all services possibly filtered by some creteria, based on some specified pagination information.
		public async Task<List<GetServiceDTO>> GetAll(ServiceFilterQueryObject filterObject)
		{
			var services = context.Services
				.Where(s => !s.IsDeleted)
				.AsQueryable()
				.FilterServices(filterObject)
				.OrderBy(s=>s.Name);		

			return await services.Select(x => new GetServiceDTO(x))
				.ToListAsync();
		}

		//Gets a service with specific id.
		public async Task<GetServiceDTO> GetAsync(int id)
		{
			var service = await context.Services
			   .FirstOrDefaultAsync(v => v.Id == id);

			//Returns null when there is not a service with this id or when is deleted.
			if (service == null || service.IsDeleted)
			{
				return null;
			}

			return new GetServiceDTO(service);
		}

		//Updates a service with specific id.
		public async Task<bool> UpdateAsync(UpdateServiceDTO updateInformation, int id)
		{
			var service = await context.Services
			 .FirstOrDefaultAsync(v => v.Id == id);

			//Returns null when there is not a service with this id or when is deleted.
			if (service == null || service.IsDeleted)
			{
				return false;
			}

			if (updateInformation.Price != null && updateInformation.Price != service.Price)
			{
				service.IsDeleted = true;
				var newService = new Data.Models.Service();
				newService.UpdateService(updateInformation);
				await context.Services.AddAsync(newService);
			}
			else
			{
				service.UpdateService(updateInformation);
			}
				context.Update(service);

			await context.SaveChangesAsync();
			return true;
		}

		//Gets all services linked to customer, possibly filtered by some creteria, based on some specified pagination information.
		public async Task<List<GetServiceDTO>> GetAllLinkedToCustomer(CustomerServicesFilterQueryObject filterObject, int userId)
		{
			var servicesOrders = context.ServiceOrders
				.Include(so => so.Service)
				.Include(so => so.Order)
				.ThenInclude(o => o.Vehicle)
				.ThenInclude(v => v.User)
				.Where(so => so.Order.Vehicle.User.Id == userId)
				.FilterCustomerServices(filterObject)
				.OrderBy(s => s.Service.Name);

			//Returns null when there aren't any services linked to the customer.		

			return await servicesOrders.Select(x => new GetServiceDTO(x.Service))
				.ToListAsync();
		}
	}
}
