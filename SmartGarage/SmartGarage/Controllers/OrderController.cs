using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;
		private readonly IUserManagerWrapper userManagerWrapper;
		private readonly IServiceService serviceService;
		private readonly IManufacturerService manufacturerService;
		private readonly IVehicleModelService vehicleModelService;

		public OrderController(IOrderService orderService,
		IUserManagerWrapper userManagerWrapper,
		IServiceService serviceService,
		IManufacturerService manufacturerService,
		IVehicleModelService vehicleModelService)
		{
			this.orderService = orderService;
			this.userManagerWrapper = userManagerWrapper;
			this.serviceService = serviceService;
			this.manufacturerService = manufacturerService;
			this.vehicleModelService = vehicleModelService;
		}

		public async Task<IActionResult> Index()
		{
			string name = default;
			int pageNumber = 1;
			var pageSize = 6;
			var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);

			var orders = await orderService.GetAll(user, name);

			return View(PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}

		[HttpGet("Order/Search")]
		public async Task<IActionResult> IndexPartial(string name, int pageNumber = 1)
		{
			var pageSize = 6;
			var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);

			var orders = await orderService.GetAll(user, name);

			return PartialView("Order_Table_Partial", PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}


		[HttpGet()]
		public async Task<IActionResult> Details(int id, [FromQuery] string currency = "EUR")
		{
			try
			{
				var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);

				var order = await orderService.GetAsync(id, user, currency);

				if (order == null)
				{
					return NotFound();
				}
				return View(order);
			}
			catch (Exception)
			{
				return Unauthorized();
			}
		}

		public async Task<IActionResult> Create()
		{
			var model = new CreateOrderViewModel
			{
				Manufacturers = await manufacturerService.GetAll(),
				Models = await vehicleModelService.GetAll()
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Create(CreateOrderViewModel order)
		{
			var createOrder = new CreateOrderDTO
			{
				FirstName = order.FirstName,
				LastName=order.LastName,
				UserName=order.UserName,
				Email=order.Email,
				PhoneNumber=order.PhoneNumber,
				Address=order.Address,
				Age=order.Age,
				DrivingLicenseNumber=order.DrivingLicenseNumber,
				NumberPlate=order.NumberPlate,
				Colour=order.Colour,
				GarageName=order.GarageName,
				VehicleModelId=order.VehicleModelId,
				VIN=order.VIN

			};
			
				await orderService.CreateAsync(createOrder);
				return RedirectToAction(nameof(Index));
					
		}


		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		[HttpPost()]
		public async Task<IActionResult> Edit(int id, OrderEditViewModel orderEditViewModel)
		{
			if (ModelState.IsValid)
			{
				var updateInformation = new UpdateOrderDTO
				{
					OrderStatusId = orderEditViewModel.OrderStatusId,
				};

				try
				{
					await orderService.UpdateAsync(id, updateInformation);
					return RedirectToAction(nameof(Index));
				}
				catch (System.Exception)
				{
					return RedirectToAction("Edit", "Service");
				}
			}

			return View(orderEditViewModel);
		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpGet()]
		public async Task<IActionResult> Edit(int id)
		{
			var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);
			var orderModel = await orderService.GetAsync(id, user);

			if (orderModel == null)
			{
				return NotFound();
			}

			var viewModel = new OrderEditViewModel
			{
				OrderStatusId = orderModel.OrderStatusId,
			};

			return View(viewModel);

		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpGet()]
		public async Task<IActionResult> EditServices(int id)
		{
			var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);
			var order = await orderService.GetAsync(id, user);
			var model = new ServiceOrderViewModel
			{
				OrderId = order.Id,
				UsedServices = order.Services.ToList(),
				AvailableServices = await serviceService.GetAvailableServices(order.Id),
				ArrivalDate = order.ArrivalDate,
				CustomerName = order.CustomerName,
				OrderStatus = order.OrderStatus,
				VehicleNumberPlate = order.VehicleNumberPlate,
				TotalPrice = order.TotalPrice
			};
			if (model == null)
			{
				return NotFound();
			}

			return View(model);
		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpPost()]
		public async Task<IActionResult> AddServiceToOrder(ServiceOrderViewModel serviceOrderViewModel)

		{
			var serviceOrder = new ServiceOrder
			{
				OrderId = serviceOrderViewModel.OrderId,
				ServiceId = serviceOrderViewModel.AvailableServiceId
			};

			await orderService.AddService(serviceOrder);

			return RedirectToAction("EditServices", new { id = serviceOrder.OrderId });
		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpGet()]
		public async Task<IActionResult> DeleteService([FromQuery] int orderId, [FromQuery] int serviceId)
		{
			var serviceOrder = new ServiceOrder
			{
				OrderId = orderId,
				ServiceId = serviceId
			};
			await orderService.DeleteService(serviceOrder);
			return RedirectToAction("EditServices", new { id = serviceOrder.OrderId });
		}
	}
}
