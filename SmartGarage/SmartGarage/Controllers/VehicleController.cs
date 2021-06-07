using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            int pageNumber = 1;
            string name = default;
            var pageSize = 10;
            var vehicles = await service.GetAll(name);

            if (user.CurrentRole == "CUSTOMER")
            {
                vehicles = vehicles.Where(v => v.UserId == user.Id).ToList();

                return View(PaginatedList<GetVehicleDTO>.CreateAsync(vehicles, pageNumber, pageSize));
            }
            return View(PaginatedList<GetVehicleDTO>.CreateAsync(await service.GetAll(name), pageNumber, pageSize));
        }

        [HttpGet("Vehicle/Filter")]
        public async Task<IActionResult> PartialView(string name, int pageNumber = 1)
        {
            var pageSize = 10;
            return PartialView("Vehicle_Table_Partial", PaginatedList<GetVehicleDTO>.CreateAsync(await service.GetAll(name), pageNumber, pageSize));
        }

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
                UserId = vehicle.UserId,
                VIN = vehicle.VIN,
                NumberPlate = vehicle.NumberPlate,
                Colour = vehicle.Colour,
                Manufacturers = await manufacturerService.GetAll(),
                Models = await vehicleModelService.GetAll()
            };

            return View(vehicleToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, VehicleViewModel updateInformation)
        {
            var vehicleInformation = new UpdateVehicleDTO
            {
                VehicleModelId = updateInformation.VehicleModelId,
                UserId = updateInformation.UserId,
                VIN = updateInformation.VIN,
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

        public async Task<IActionResult> Create()
        {
            var model = new VehicleViewModel
            {
                Manufacturers = await manufacturerService.GetAll(),
                Models = await vehicleModelService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(VehicleViewModel vehicle)
        {
            var createVehicle = new CreateVehicleDTO
            {
                UserId = vehicle.UserId,
                NumberPlate = vehicle.NumberPlate,
                Colour = vehicle.Colour,
                VehicleModelId = vehicle.VehicleModelId,
                VIN = vehicle.VIN
            };

            await service.CreateAsync(createVehicle);
            return RedirectToAction(nameof(Index));
        }

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

