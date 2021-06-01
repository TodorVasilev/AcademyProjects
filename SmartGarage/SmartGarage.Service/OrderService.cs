﻿using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
	public class OrderService : IOrderService
	{
		private readonly SmartGarageContext context;

		private readonly ICurrencyService currencyService;
		private readonly IUserService userService;
		private readonly IUserHelper userHelperService;
		private readonly IVehicleService vehicleService;

		public OrderService(SmartGarageContext context,
		ICurrencyService currencyService,
		IUserService userService,
		IUserHelper userHelperService,
		IVehicleService vehicleService)
		{
			this.context = context;
			this.currencyService = currencyService;
			this.userService = userService;
			this.userHelperService = userHelperService;
			this.vehicleService = vehicleService;
		}

		public async Task<List<GetOrderDTO>> GetAll(User user, string name)
		{
			var orders = context.Orders
			  .Include(o => o.ServiceOrder)
					.ThenInclude(so => so.Service)
			  .Include(o => o.Garage)
			  .Include(o => o.OrderStatus)
			  .Include(o => o.Vehicle)
					.ThenInclude(v => v.User)
			  .AsQueryable();

			if (name != default)
			{
				orders = orders.Where(o => o.Vehicle.User.FirstName.ToUpper().Contains(name.ToUpper()) ||
				o.Vehicle.User.LastName.ToUpper().Contains(name.ToUpper()));
			}

			if (user.CurrentRole == "CUSTOMER")
			{
				orders = orders.Where(o => o.Vehicle.UserId == user.Id);
			}

			orders = orders.OrderByDescending(o => o.ArrivalDate);
			return await orders.Select(order => new GetOrderDTO(order))
				.ToListAsync();
		}

		public async Task<GetOrderDTO> GetAsync(int id, string currency = "EUR")
		{
			var order = await this.context.Orders
				.Include(o => o.ServiceOrder)
						.ThenInclude(so => so.Service)
				.Include(o => o.Garage)
				.Include(o => o.OrderStatus)
				.Include(o => o.Vehicle)
						.ThenInclude(v => v.User)
				.FirstOrDefaultAsync(o => o.Id == id);

			if (order == null || order.IsDeleted == true)
			{
				return null;
			}

			decimal currencyRate = default;
			if (order.FinishDate == null)
			{
				currencyRate = currencyService.Convert(System.DateTime.Now, currency).Result;
			}
			else
			{
				currencyRate = currencyService.Convert(order.FinishDate.Value, currency).Result;
			}

			var result = new GetOrderDTO(order);
			foreach (var item in result.Services)
			{
				item.Price *= currencyRate;
			}

			result.TotalPrice *= currencyRate;

			return result;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var order = await context.Orders.FindAsync(id);
			if (order == null || order.IsDeleted == true)
			{
				return false;
			}
			order.IsDeleted = true;
			this.context.SaveChanges();
			return true;
		}
		public async Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder)
		{
			var orderToUpdate = await context.Orders.FindAsync(id);

			if (orderToUpdate == null || orderToUpdate.IsDeleted == true)
			{
				return false;
			}
			if (updateOrder.GarageId != 0)
			{
				orderToUpdate.GarageId = updateOrder.GarageId;
			}
			if (updateOrder.OrderStatusId != 0)
			{
				orderToUpdate.OrderStatusId = updateOrder.OrderStatusId;
			}
			if (updateOrder.FinishDate.Value >= orderToUpdate.ArrivalDate.Date && updateOrder.FinishDate.Value != null)
			{
				orderToUpdate.FinishDate = updateOrder.FinishDate;
			}
			if (updateOrder.VehicleId != 0)
			{
				orderToUpdate.VehicleId = updateOrder.VehicleId;
			}

			await this.context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> CreateAsync(CreateOrderDTO createOrderDTO)
		{
			if (createOrderDTO.GarageName == default)
			{
				return false;
			}

			var user = await this.context.Users.FirstOrDefaultAsync(u => u.Email == createOrderDTO.Email);
			if (user == null)
			{
				var createUser = new CreateUserDTO()
				{
					Address = createOrderDTO.Address,
					Age = createOrderDTO.Age,
					DrivingLicenseNumber = createOrderDTO.DrivingLicenseNumber,
					Email = createOrderDTO.Email,
					FirstName = createOrderDTO.FirstName,
					LastName = createOrderDTO.LastName,
					PhoneNumber = createOrderDTO.PhoneNumber,
					UserName = createOrderDTO.UserName
				};
				await userHelperService.CreateUserAsync(createUser);
				user = await this.context.Users.FirstOrDefaultAsync(u => u.Email == createOrderDTO.Email);
			}

			var vehicle = await this.context.Vehicles.FirstOrDefaultAsync(v => v.NumberPlate == createOrderDTO.NumberPlate);
			var vehicleId = 0;
			if (vehicle == null)
			{
				var createVehicle = new CreateVehicleDTO()
				{
					Colour = createOrderDTO.Colour,
					NumberPlate = createOrderDTO.NumberPlate,
					VIN = createOrderDTO.VIN,
					UserId = user.Id,
					VehicleModelId = createOrderDTO.VehicleModelId,
				};
				var tempVehicle = await vehicleService.CreateAsync(createVehicle);
				vehicleId = tempVehicle.Id;
			}
			else
			{
				vehicleId = vehicle.Id;
			}
			var garage = await this.context.Garages.FirstOrDefaultAsync(g => g.Name == createOrderDTO.GarageName);
			if (garage == null)
			{
				return false;
			}
			var newOrder = new Order
			{
				GarageId = garage.Id,
				ArrivalDate = System.DateTime.Now,
				OrderStatusId = 1,
				VehicleId = vehicleId
			};

			await this.context.AddAsync(newOrder);
			this.context.SaveChanges();

			return true;
		}

		public async Task<bool> AddService(List<ServiceOrder> serviceOrder)
		{
			await this.context.ServiceOrders.AddRangeAsync(serviceOrder);
			await this.context.SaveChangesAsync();

			return true;
		}
	}
}
