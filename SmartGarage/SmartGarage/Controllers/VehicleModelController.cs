using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
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

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = 5;
            return View(PaginatedList<GetVehicleModelDTO>.CreateAsync(await service.GetAll(), pageNumber, pageSize));
        }
    }
}
