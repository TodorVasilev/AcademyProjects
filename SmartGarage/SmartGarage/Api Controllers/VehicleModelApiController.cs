﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/vehiclemodels")]
    public class VehicleModelApiController : ControllerBase
    {
        private readonly IVehicleModelService service;

        public VehicleModelApiController(IVehicleModelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all vehicle models based on some specified pagination information.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            return Ok(PaginatedList<GetVehicleModelDTO>.CreateAsync(await service.GetAll(), pageNumber, pageSize));
        }

        /// <summary>
        /// Gets vehicle model with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Employee")]
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
        [Authorize(Roles = "Admin,Employee")]
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
        [Authorize(Roles = "Admin,Employee")]
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