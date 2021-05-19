using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.QueryObjects;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all services possibly filtered by some criteria, based on some specified pagination information.
        /// </summary>
        /// <param name="pagination">The pagination information.</param>
        /// <param name="filterObject">The filter information.</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PaginationQueryObject pagination, ServiceFilterQueryObject filterObject)
        {
            var services = await service.GetAllAsync(pagination, filterObject);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        /// <summary>
        ///Gets all services linked to user, possibly filtered by some criteria and based on some specified pagination information.
        /// </summary>
        /// <param name="pagination">The pagination information.</param>
        /// <param name="filterObject">The filter information.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("User")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PaginationQueryObject pagination, [FromQuery]CustomerServicesFilterQueryObject filterObject, int userID)
        {
            var services = await service.GetAllLinkedToCustomerAsync(pagination, filterObject, userID);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        /// <summary>
        /// Gets service with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var service = await this.service.GetAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return base.Ok(service);
        }

        /// <summary>
        /// Deletes service with specified identifier using soft delete.
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
        /// Updates service with specified identifier.
        /// </summary>
        /// <param name="updateInformation">The update information.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdateServiceDTO updateInformation, int id)
        {
            var result = await service.UpdateAsync(updateInformation, id);

            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Creates new service.
        /// </summary>
        /// <param name="serviceInformation">The vehicle information.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateServiceDTO serviceInformation)
        {
            try
            {
                var vehicle = await service.CreateAsync(serviceInformation);

                return Ok(vehicle);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }


        }
    }
}
