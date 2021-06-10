using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using SmartGarage.ViewModels;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
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

        // GET: VehicleModels
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index()
        {
            int pageNumber = 1;
            var pageSize = 8;
            var services= await service.GetAll();
            return View(PaginatedList<GetVehicleModelDTO>.CreateAsync(services, pageNumber, pageSize));
        }

        [HttpGet("VehicleModel/Get")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> IndexParital(int pageNumber = 1)
        {
            var pageSize = 8;
            var services = await service.GetAll();
            return PartialView("VehicleModel_Table_Partial", PaginatedList<GetVehicleModelDTO>.CreateAsync(services, pageNumber, pageSize));
        }

        // GET: VehicleModels/Create
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

        // POST: VehicleModels/Create
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

        // GET: VehicleModels/Edit/5
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

        // POST: VehicleModels/Edit/5
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, VehicleModelViewModel vehicleModel)
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
