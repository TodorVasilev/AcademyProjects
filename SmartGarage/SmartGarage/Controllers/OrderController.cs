﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService service;
		private readonly UserManager<User> userManager;

		public OrderController(IOrderService service, UserManager<User> userManager)
		{
			this.service = service;
			this.userManager = userManager;
		}

		public async Task<IActionResult> Index(string name, int pageNumber = 1)
		{
			var pageSize = 10;
			var user = await userManager.FindByNameAsync(User.Identity.Name);

			var orders = await service.GetAll(user, name);

			return View(PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}

		[HttpGet()]
		public async Task<IActionResult> Details(int id, [FromQuery] string currency = "EUR")
		{
			var order = await service.GetAsync(id, currency);

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
				await service.CreateAsync(createOrderDTO);
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
					await service.UpdateAsync(id, updateInformation);
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
				var orderModel = await service.GetAsync(id);

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

	}
}
