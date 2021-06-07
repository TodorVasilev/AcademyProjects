using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.Helpers;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypeApiController : ControllerBase
    {
        private readonly IVehicleTypeService service;

        public VehicleTypeApiController(IVehicleTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            var vehicleType = await service.GetAll();

            if(vehicleType.Count == 0)
            {
                return NotFound();
            }

            return Ok(PaginatedList<VehicleType>.CreateAsync(vehicleType, pageNumber, pageSize));
        }
    }
}
