using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceContracts;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService service;

        public VehicleController(IVehicleService service)
        {
            this.service = service;
        }

        /// <summary>
        /// //Gets all vehicles possibly filtered by name, based on some specified pagination information..
        /// </summary>
        /// <param name="pagination">The pagination information.</param>
        /// <param name="name">The name of the vehicle.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PaginationQueryObject pagination, string name)
        {
            var vehicles = await service.GetAllAsync(pagination, name);

            if (vehicles.ItemsOnPage == 0)
            {
                return NotFound();
            }

            return Ok(vehicles);
        }

        /// <summary>
        /// Gets vehicle with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await service.GetAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        /// <summary>
        /// Deletes vehicle with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.RemoveAsync(id);

            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Updates vehicle with specified update information.
        /// </summary>
        /// <param name="updateInformation">The update information.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdateVehicleDTO updateInformation, int id)
        {
            var result = await service.UpdateAsync(updateInformation, id);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Creates vehicle.
        /// </summary>
        /// <param name="vehicleInformation">The vehicle information.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateVehicleDTO vehicleInformation)
        {
            var vehicle = await service.CreateAsync(vehicleInformation);

            if (vehicle == null)
            {
                return BadRequest();
            }

            return Ok(vehicle);
        }
    }
}
