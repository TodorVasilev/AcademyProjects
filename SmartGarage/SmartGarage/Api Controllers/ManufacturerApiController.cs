using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.Shared;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerApiController : ControllerBase
    {
        private readonly IManufacturerService service;

        public ManufacturerApiController(IManufacturerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all manufacturers based on some specified pagination information.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            return Ok(PaginatedList<GetManufacturerDTO>.CreateAsync(await service.GetAll(), pageNumber, pageSize));
        }

        /// <summary>
        /// Gets manufaturer with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var manufacturer = await service.GetAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        /// <summary>
        /// Updates manufacturer with specified update information.
        /// </summary>
        /// <param name="updateInformation">The update information.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] ManufacturerDTO updateInformation, int id)
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
        /// Creates manufacturer.
        /// </summary>
        /// <param name="vehicleModelInformation">The vehicle information.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ManufacturerDTO vehicleModelInformation)
        {
            try
            {
                var manufacturer = await service.CreateAsync(vehicleModelInformation);

                return Ok(manufacturer);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
