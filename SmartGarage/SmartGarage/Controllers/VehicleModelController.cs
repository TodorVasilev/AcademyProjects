using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
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

        public VehicleModelController(IVehicleModelService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = 1;
            return View(PaginatedList<GetVehicleModelDTO>.CreateAsync(await service.GetAll(), pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleModel = await service.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            var viewModel = new VehicleModelEditViewModel
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.ManafacturerName,
                ManufacturerId = vehicleModel.ManufacturerId,
                VehicleTypeId = vehicleModel.VehicleTypeId
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
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(VehicleModelDTO vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(vehicleModel);
                return RedirectToAction(nameof(Index));
            }

            return View(vehicleModel);
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

            if (ModelState.IsValid)
            {
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

            return View(vehicleModel);
        }
    }
}
