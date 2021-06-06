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
		private readonly UserManager<User> userManager;
		private readonly IServiceService serviceService;
        private readonly IEmailsService emailsService;

        public OrderController(IOrderService orderService, UserManager<User> userManager, IServiceService serviceService, IEmailsService emailsService)
		{
			this.orderService = orderService;
			this.userManager = userManager;
			this.serviceService = serviceService;
            this.emailsService = emailsService;
        }

		public async Task<IActionResult> Index()
		{
			string name=default;
			int pageNumber = 1;
			var pageSize = 10;
			var user = await userManager.FindByNameAsync(User.Identity.Name);

			var orders = await orderService.GetAll(user, name);

			return View(PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}

		[HttpGet("Order/Search")]
		public async Task<IActionResult> IndexPartial(string name, int pageNumber = 1)
		{
			var pageSize = 10;
			var user = await userManager.FindByNameAsync(User.Identity.Name);

			var orders = await orderService.GetAll(user, name);

			return PartialView("Order_Table_Partial",PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}



		[HttpGet()]
		public async Task<IActionResult> Details(int id, [FromQuery] string currency = "EUR")
		{
			var order = await orderService.GetAsync(id, currency);

			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Create(CreateOrderDTO createOrderDTO)
		{
			if (ModelState.IsValid)
			{
				await orderService.CreateAsync(createOrderDTO);
				return RedirectToAction(nameof(Index));
			}

			return View(createOrderDTO);
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
					VehicleId = orderEditViewModel.VehicleId,
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
			{
				var orderModel = await orderService.GetAsync(id);

				if (orderModel == null)
				{
					return NotFound();
				}

				var viewModel = new OrderEditViewModel
				{
					OrderStatusId = orderModel.OrderStatusId,
					VehicleId = orderModel.VehicleId,
				};

				return View(viewModel);
			}
		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpGet()]
		public async Task<IActionResult> EditServices(int id)
		{
			var order = await orderService.GetAsync(id);
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

		public async Task SendPdf(int id)
        {
			var orderModel = await orderService.GetAsync(id);
			await emailsService.SendPdfWithOrderDetails(orderModel,orderModel.UserEmail);
        }
	}
}
