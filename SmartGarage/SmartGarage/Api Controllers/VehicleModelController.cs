using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService service;

        public VehicleModelController(IVehicleModelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all vehicle models based on some specified pagination information.
        /// </summary>
        /// <param name="pagination">The pagination information.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PaginationQueryObject pagination)
        {
            var vehicleModels = await service.GetAllAsync(pagination);

            if (vehicleModels.ItemsOnPage == 0)
            {
                return NotFound();
            }

            return Ok(vehicleModels);
        }

        /// <summary>
        /// Gets vehicle model with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var vehicleModel = await service.GetAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        /// <summary>
        /// Updates vehicle model with specified update information.
        /// </summary>
        /// <param name="updateInformation">The update information.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] VehicleModelDTO updateInformation, int id)
        {
            try
            {
                var result = await service.UpdateAsync(updateInformation, id);

                if (result == false)
                {
                    return NotFound();
                }

                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates vehicle.
        /// </summary>
        /// <param name="vehicleModelInformation">The vehicle information.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] VehicleModelDTO vehicleModelInformation)
        {
            try
            {
                var vehicleModel = await service.CreateAsync(vehicleModelInformation);

                return Ok(vehicleModel);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
