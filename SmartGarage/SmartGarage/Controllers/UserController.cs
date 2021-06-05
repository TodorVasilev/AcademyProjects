using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService service;

		public UserController(IUserService service)
		{
			this.service = service;
		}

		public async Task<IActionResult> Index()
		{
			int pageNumber = 1;
			var pageSize = 10;
			var filer = new UserSevicesFilterQueryObject();
			var order = new UserOrderQueryObject();

			var users = await service.GetAllCustomerAsync(filer, order);

			return View(PaginatedList<GetUserDTO>.CreateAsync(users, pageNumber, pageSize));
		}

		[HttpGet("User/Search")]
		public async Task<IActionResult> IndexPartial(UserSevicesFilterQueryObject filer, UserOrderQueryObject order, int pageNumber = 1)
		{
			var pageSize = 10;

			var users = await service.GetAllCustomerAsync(filer, order);

			return PartialView("User_Table_Partial", PaginatedList<GetUserDTO>.CreateAsync(users, pageNumber, pageSize));
		}

		public IActionResult UpdateAdmin()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> UpdateAdmin(UpdateAdminViewModel model)
		{
			var result = await service.UpdateAdminAsync(model.Email, model.Role);
			if (result == false)
			{
				TempData["Error"] = "Wrong email or role.";
			}
			else
			{
				TempData["Success"] = "Update is completed";
			}
			return View();
		}
	}
}
