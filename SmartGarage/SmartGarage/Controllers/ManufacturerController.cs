using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.Shared;
using SmartGarage.Service.Helpers;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService service;

        public ManufacturerController(IManufacturerService service)
        {
            this.service = service;
        }

        public SmartGarageContext Context { get; }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = 10;
            var manufacturers = await service.GetAll();

            if(manufacturers.Count == 0)
            {
                return Ok();
            }
            return View(PaginatedList<GetManufacturerDTO>.CreateAsync(manufacturers, pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Details(int id)
        {
            var manufacturer = await service.GetAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturer = await service.GetAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateInformaniton = new ManufacturerDTO
                {
                    Name = manufacturer.Name
                };

                await service.UpdateAsync(updateInformaniton, id);
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(ManufacturerDTO manufacturer)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }
    }
}