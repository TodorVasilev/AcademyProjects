using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.ViewModels;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService service;

        public VehicleController(IVehicleService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index(string name, int pageNumber = 1)
        {
            var pageSize = 3;
            return View(PaginatedList<GetVehicleDTO>.CreateAsync(await service.GetAll(name), pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await service.GetAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await service.GetAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleToUpdate = new VehicleEditViewModel
            {
                Id = vehicle.Id,
                VehicleModelId = vehicle.VehicleModelId,
                UserId = vehicle.UserId,
                VIN = vehicle.VIN,
                NumberPlate = vehicle.NumberPlate,
                Colour = vehicle.Colour
            };

            return View(vehicleToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleEditViewModel updateInformation)
        {
            if (id != updateInformation.Id)
            {
                return NotFound();
            }

            var vehicleInformation = new UpdateVehicleDTO
            {
                VehicleModelId = updateInformation.VehicleModelId,
                UserId = updateInformation.UserId,
                VIN = updateInformation.VIN,
                NumberPlate = updateInformation.NumberPlate,
                Colour = updateInformation.Colour
            };

            if (ModelState.IsValid)
            {
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

            return View(vehicleInformation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVehicleDTO vehicle)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

