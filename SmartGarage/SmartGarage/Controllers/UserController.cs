using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			int pageNumber = 1;
			var pageSize = 10;
			var filer = new UserSevicesFilterQueryObject();
			var order = new UserOrderQueryObject();

			var users = await userService.GetAllCustomerAsync(filer, order);

			return View(PaginatedList<GetUserDTO>.CreateAsync(users, pageNumber, pageSize));
		}

		[HttpGet("User/Search")]
		public async Task<IActionResult> IndexPartial(UserSevicesFilterQueryObject filer, UserOrderQueryObject order, int pageNumber = 1)
		{
			var pageSize = 10;

			var users = await userService.GetAllCustomerAsync(filer, order);

			return PartialView("User_Table_Partial",PaginatedList<GetUserDTO>.CreateAsync(users, pageNumber, pageSize));
		}
	}
}
