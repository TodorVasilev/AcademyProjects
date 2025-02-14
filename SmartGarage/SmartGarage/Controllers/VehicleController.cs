﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService service;
        private readonly IManufacturerService manufacturerService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly UserManager<User> userManager;

        public VehicleController(IVehicleService service,
            IManufacturerService manufacturerService,
            IVehicleModelService vehicleModelService,
            UserManager<User> userManager)
        {
            this.service = service;
            this.manufacturerService = manufacturerService;
            this.vehicleModelService = vehicleModelService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin,Employee,Customer")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            int pageNumber = 1;
            string name = default;
            var pageSize = 8;
            var vehicles = await service.GetAll(name);

            if (user.CurrentRole == "CUSTOMER")
            {
                vehicles = vehicles.Where(v => v.UserId == user.Id).ToList();

                return View(PaginatedList<GetVehicleDTO>.CreateAsync(vehicles, pageNumber, pageSize));
            }
            return View(PaginatedList<GetVehicleDTO>.CreateAsync(await service.GetAll(name), pageNumber, pageSize));
        }

        [HttpGet("Vehicle/Filter")]
        [Authorize(Roles = "Admin,Employee,Customer")]
        public async Task<IActionResult> PartialView(string name, int pageNumber = 1)
        {
            var pageSize = 8;
            return PartialView("Vehicle_Table_Partial", PaginatedList<GetVehicleDTO>.CreateAsync(await service.GetAll(name), pageNumber, pageSize));
        }

        // GET: Vehicles/Details/5
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await service.GetAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Details/5
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await service.GetAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleToUpdate = new VehicleViewModel
            {
                Id = vehicle.Id,
                VehicleModelId = vehicle.VehicleModelId,
                VIN = vehicle.VIN,
                NumberPlate = vehicle.NumberPlate,
                Colour = vehicle.Colour,
                Manufacturers = await manufacturerService.GetAll(),
                Models = await vehicleModelService.GetAll()
            };

            return View(vehicleToUpdate);
        }

        // POST: Vehicles/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, VehicleViewModel updateInformation)
        {
            var vehicleInformation = new UpdateVehicleDTO
            {
                NumberPlate = updateInformation.NumberPlate,
                Colour = updateInformation.Colour
            };

            try
            {
                await service.UpdateAsync(vehicleInformation, id);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                return RedirectToAction("Edit", "VehicleModel");
            }
        }

        // GET: Vehicles/Create
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create()
        {
            var model = new VehicleViewModel
            {
                Manufacturers = await manufacturerService.GetAll(),
                Models = await vehicleModelService.GetAll()
            };

            return View(model);
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(VehicleViewModel vehicle, int id)
        {
            if (vehicle.ManufacturerId == default || vehicle.VehicleModelId == default)
            {
                TempData["Error"] = "Please select existing manufacturer and vehicle model.";
                return RedirectToAction("Index","User");
            }

            var createVehicle = new CreateVehicleDTO
            {
                UserId = id,
                NumberPlate = vehicle.NumberPlate,
                Colour = vehicle.Colour,
                VehicleModelId = vehicle.VehicleModelId,
                VIN = vehicle.VIN
            };

            await service.CreateAsync(createVehicle);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vehicles/Delete/5
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleToRemove = await service.GetAsync(id);

            if (vehicleToRemove == null)
            {
                return NotFound();
            }

            return View(vehicleToRemove);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VehicleModels(int? id)
        {
            var models = await vehicleModelService.GetAll();

            return Json(models.Where(x => x.ManufacturerId == id).ToList());
        }
    }
}

