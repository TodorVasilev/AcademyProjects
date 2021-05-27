using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
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
		public async Task<IActionResult> Create(CreateServiceDTO serviceDTO)
		{
			if (ModelState.IsValid)
			{
				await service.CreateAsync(serviceDTO);
				return RedirectToAction(nameof(Index));
			}

			return View(serviceDTO);
		}

	}
}
