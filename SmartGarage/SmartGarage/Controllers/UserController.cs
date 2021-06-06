using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.ViewModels;
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

		[HttpGet()]
		public async Task<IActionResult> Details(int id)
		{
			var user = await service.GetById(id);

			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> Delete(int id)
		{
			var user = await service.GetById(id);

			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,Employee")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var isDeleted = await service.Delete(id);
			if (isDeleted)
			{
				return RedirectToAction(nameof(Index));
			}
			return NotFound();
		}


		[Authorize(Roles = "Admin,Employee")]
		[HttpPost()]
		public async Task<IActionResult> Edit(int id, UpdateUserViewModel updateUserViewModel)
		{
			if (ModelState.IsValid)
			{
				var updateInformation = new UpdateUserDTO()
				{
					FirstName = updateUserViewModel.FirstName,
					LastName = updateUserViewModel.LastName,
					DrivingLicenseNumber = updateUserViewModel.DrivingLicenseNumber,
					Address = updateUserViewModel.Address,
					Age = updateUserViewModel.Age,
					Email = updateUserViewModel.Email,
					PhoneNumber = updateUserViewModel.PhoneNumber,
					UserName = updateUserViewModel.UserName,
				};


				var isUpdated = await service.UpdateUserAsync(id, updateInformation);
				if (isUpdated)
				{
					return RedirectToAction(nameof(Index));
				}
				TempData["Error"] = "Email or User name is already in use.";
				return RedirectToAction("Edit", "User");

			}

			return View(updateUserViewModel);
		}

		[Authorize(Roles = "Admin,Employee")]
		[HttpGet()]
		public async Task<IActionResult> Edit(int id)
		{
			{
				var user = await service.GetById(id);

				if (user == null)
				{
					return NotFound();
				}

				var viewModel = new UpdateUserViewModel
				{
					UserName = user.UserName,
					FirstName = user.FirstName,
					LastName = user.LastName,
					PhoneNumber = user.PhoneNumber,
					Age = user.Age,
					DrivingLicenseNumber = user.DrivingLicenseNumber,
					Address = user.Address,
					Email = user.Email,
				};

				return View(viewModel);
			}
		}
	}
}
