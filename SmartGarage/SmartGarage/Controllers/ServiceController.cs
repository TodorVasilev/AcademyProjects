using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IServiceService service;
		private readonly UserManager<User> userManager;

		public ServiceController(IServiceService service, UserManager<User> userManager)
		{
			this.service = service;
			this.userManager = userManager;
		}


		public async Task<IActionResult> IndexCustomer(DateTime date, string numberPlate, int pageNumber = 1)
		{
			var filterForCustomer = new CustomerServicesFilterQueryObject
			{
				NumberPlate = numberPlate,
				VisitDate = date
			};

			var pageSize = 10;

			var user = await userManager.GetUserAsync(HttpContext.User);

			var services = await service.GetAllLinkedToCustomer(filterForCustomer, user.Id);
			if (services == null)
			{
				return View();
			}
			return View(PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));

		}

		public async Task<IActionResult> Index(decimal? price, string name, int pageNumber = 1)
		{
			var pageSize = 10;
			var filterService = new ServiceFilterQueryObject
			{
				Name = name,
				Price = price
			};
			var services = await service.GetAll(filterService);

			return View(PaginatedList<GetServiceDTO>.CreateAsync(services, pageNumber, pageSize));
		}


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
				return RedirectToAction(nameof(Index));
			}

			return View(serviceDTO);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Edit(int id, Data.Models.Service serviceModel)
		{
			if (id != serviceModel.Id)
			{
				return NotFound();
			}

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

	}
}
