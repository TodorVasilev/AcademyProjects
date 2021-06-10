using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/orders")]
    public class OrdersApiController : ControllerBase
    {
        private readonly IOrderService service;

        private readonly IUserManagerWrapper userManagerWrapper;

        public OrdersApiController(IOrderService service, IUserManagerWrapper userManagerWrapper)
        {
            this.service = service;
            this.userManagerWrapper = userManagerWrapper;
        }
        /// <summary>
        /// Gets all orders, filter by name.
        /// </summary>
        /// <param name="filterByName">Filter by user name.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Employee,Customer")]
        public async Task<IActionResult> Get([FromQuery] string filterByName, [FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 1)
        {
            var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);

            return Ok(PaginatedList<GetOrderDTO>.CreateAsync(await service.GetAll(user, filterByName), pageNumber, pageSize));
        }

        /// <summary>
        /// Gets order by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin,Employee,Customer")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await userManagerWrapper.FindByNameAsync(User.Identity.Name);
            try
            {
                var order = await this.service.GetAsync(id, user);

                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (ArgumentException)
            {
                return Unauthorized("You are not Autorized.");
            }
        }

        /// <summary>
        /// Deletes specific Order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDelete = await this.service.DeleteAsync(id);
            if (isDelete == false)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Updates order by specific Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateOrder">The update order.</param>
        /// <returns></returns>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOrderDTO updateOrder)
        {
            var isUpdated = await this.service.UpdateAsync(id, updateOrder);
            if (isUpdated == false)
            {
                return NotFound();
            }
            return Ok("Order is updated!");
        }

        /// <summary>
        /// Creates order asynchronous.
        /// </summary>
        /// <param name="createOrder">The create order.</param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderDTO createOrder)
        {
            var isUpdated = await this.service.CreateAsync(createOrder);
            if (isUpdated == false)
            {
                return BadRequest("Enter correct input data.");
            }
            return Ok("Order is created!");
        }
    }
}
