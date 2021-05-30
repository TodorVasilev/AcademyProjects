using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService service;
        private readonly IVehicleTypeService vehicleTypeService;
        private readonly IManufacturerService manufacturerService;

        public VehicleModelController(IVehicleModelService service, IVehicleTypeService vehicleTypeService, IManufacturerService manufacturerService)
        {
            this.service = service;
            this.vehicleTypeService = vehicleTypeService;
            this.manufacturerService = manufacturerService;
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = 10;
            return View(PaginatedList<GetVehicleModelDTO>.CreateAsync(await service.GetAll(), pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create()
        {
            var viewModel = new VehicleModelViewModel
            {
                VehicleTypes = await vehicleTypeService.GetAll(),
                Manufacturers = await manufacturerService.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(VehicleModelViewModel vehicleModel)
        {

            if (vehicleModel.VehicleTypeId == default || vehicleModel.ManufacturerId == default)
            {
                TempData["Error"] = "Please select among the options";
                return RedirectToAction("Create");
            }

            var vehicleModelDTO = new VehicleModelDTO
            {
                Name = vehicleModel.Name,
                ManufacturerId = vehicleModel.ManufacturerId,
                VehicleTypeId = vehicleModel.VehicleTypeId
            };

            try
            {
                await service.CreateAsync(vehicleModelDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleModel = await service.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleModelViewModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.ManafacturerName,
                ManufacturerId = vehicleModel.ManufacturerId,
                VehicleTypeId = vehicleModel.VehicleTypeId,
                VehicleTypes = await vehicleTypeService.GetAll(),
                Manufacturers = await manufacturerService.GetAll()
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModelDTO vehicleModel)
        {
            if (vehicleModel.VehicleTypeId == default || vehicleModel.ManufacturerId == default)
            {
                return RedirectToAction("Edit");
            }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, VehicleModelEditViewModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            var updateInformation = new VehicleModelDTO
            {
                Name = vehicleModel.Name,
                ManufacturerId = vehicleModel.ManufacturerId,
                VehicleTypeId = vehicleModel.VehicleTypeId
            };

            try
            {
                await service.UpdateAsync(updateInformation, id);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                return RedirectToAction("Edit", "VehicleModel");
            }
        }
    }
}
