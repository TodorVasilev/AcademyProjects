﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.ViewModels;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)]
	[Authorize]
	public class ServiceController : Controller
	{
		private readonly IServiceService service;
		private readonly UserManager<User> userManager;

		public ServiceController(IServiceService service, UserManager<User> userManager)
		{
			this.service = service;
			this.userManager = userManager;
		}

		[Authorize(Roles = "Admin,Employee,Customer")]
		public async Task<IActionResult> IndexCustomer()
		{
			var filterForCustomer = new CustomerServicesFilterQueryObject();

			int pageNumber = 1;
			var pageSize = 6;

			var user = await userManager.GetUserAsync(HttpContext.User);

			var services = await service.GetAllLinkedToCustomer(filterForCustomer, user.Id);

			return View(PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));

		}

		[HttpGet("Service/SearchCustomer")]
		[Authorize(Roles = "Admin,Employee,Customer")]
		public async Task<IActionResult> PartialForCustomer(DateTime date, string numberPlate, int pageNumber = 1)
		{
			var filterForCustomer = new CustomerServicesFilterQueryObject
			{
				NumberPlate = numberPlate,
				VisitDate = date
			};

			var pageSize = 6;

			var user = await userManager.GetUserAsync(HttpContext.User);

			var services = await service.GetAllLinkedToCustomer(filterForCustomer, user.Id);

			return PartialView("ServiceCustomer_Table_Partial", PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));

		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			int pageNumber = 1;
			var pageSize = 6;
			var filterService = new ServiceFilterQueryObject();

			var services = await service.GetAll(filterService);

			return View(PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));
		}

		[HttpGet("Service/Search")]
		[AllowAnonymous]
		public async Task<IActionResult> PartialForAdminEmployee(decimal? price, string name, int pageNumber = 1)
		{
			var pageSize = 6;
			var filterService = new ServiceFilterQueryObject
			{
				Name = name,
				Price = price
			};
			var services = await service.GetAll(filterService);

			return PartialView("Service_Table_Partial", PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));
		}

		[Authorize(Roles = "Admin,Employee")]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Create(CreateServiceDTO serviceDTO)
		{
			if (ModelState.IsValid)
			{
				await service.CreateAsync(serviceDTO);
				if (true)
				{

				}
				return RedirectToAction(nameof(Index));
			}

			return View(serviceDTO);
		}


		[HttpPost()]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Edit(int id, ServiceEditViewModel serviceModel)
		{
			if (ModelState.IsValid)
			{
				var updateInformation = new UpdateServiceDTO
				{
					Name = serviceModel.Name,
					Price = serviceModel.Price,
				};

				try
				{
					await service.UpdateAsync(updateInformation, id);
					return RedirectToAction(nameof(Index));
				}
				catch (System.Exception)
				{
					return RedirectToAction("Edit", "Service");
				}
			}

			return View(serviceModel);
		}

		[HttpGet()]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Edit(int id)
		{
			{
				var serviceModel = await service.GetAsync(id);

				if (serviceModel == null)
				{
					return NotFound();
				}

				var viewModel = new ServiceEditViewModel
				{
					Price = serviceModel.Price,
					Name = serviceModel.Name,
				};

				return View(viewModel);
			}
		}

		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Delete(int id)
		{
			var serviceToDelete = await service.GetAsync(id);

			if (serviceToDelete == null)
			{
				return NotFound();
			}

			return View(serviceToDelete);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await service.RemoveAsync(id);

			return RedirectToAction(nameof(Index));
		}
	}
}

