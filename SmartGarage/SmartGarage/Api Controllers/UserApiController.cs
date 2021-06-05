using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	[Route("api/[controller]")]
	public class UserApiController : ControllerBase
	{
		private readonly IUserService userService;
		private readonly IUserHelper userHelper;

		public UserApiController(IUserService userService, IUserHelper userHelper)
		{
			this.userService = userService;
			this.userHelper = userHelper;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[AllowAnonymous]
		[HttpPost("authenticate")]
		public async Task<IActionResult> Authenticate([FromBody] LoginDTO model)
		{
			var loginDTO = model;

			var user = await this.userHelper.AuthenticateAsync(loginDTO);

			if (user != null)
			{
				return Ok(user);
			}

			return BadRequest(new { message = "Username or password is incorrect" });
		}

		/// <summary>
		/// Registers a user and saves it in the database
		/// </summary>
		/// <param name="createUserDTO">The create user dto.</param>
		/// <returns></returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin,Employee")]
		[HttpPost()]
		public async Task<IActionResult> RegisterUserAsync([FromBody] CreateUserDTO createUserDTO)

		{
			try
			{
				var operationResult = await this.userHelper.CreateUserAsync(createUserDTO);
				if (operationResult.Succeeded)
				{
					return Ok(new { message = "User created!" });
				}
				return BadRequest(new { message = "Unable to create user!" });
			}

			catch (System.Exception)
			{

				return BadRequest(new { massage = "There is such an email." });
			}
		}
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin,Employee")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserDTO updateUserDTO)

		{
			var operationResult = await this.userService.UpdateUserAsync(id, updateUserDTO);
			if (operationResult)
			{
				return Ok(new { message = "User updated!" });
			}
			return BadRequest(new { message = "Unable to update user!" });
		}
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin")]
		[HttpPut("admin/{id}")]
		public async Task<IActionResult> UpdateAdminAsync(string id, [FromBody] string role)

		{
			try
			{
				var operationResult = await this.userService.UpdateAdminAsync(id, role);

				if (operationResult)
				{
					return Ok(new { message = "User updated!" });
				}
				return BadRequest(new { message = "Unable to update user!" });
			}
			catch (System.Exception)
			{

				return NotFound(new { message = "There is no such a role" });
			}
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin,Employee")]
		[HttpGet("")]
		public async Task<IActionResult> GetAllUserAsync([FromQuery] UserSevicesFilterQueryObject filter, [FromQuery] UserOrderQueryObject order, int pageNumber = 1, int pageSize = 5)
		{
			var customers = PaginatedList<GetUserDTO>.CreateAsync(await userService.GetAllCustomerAsync(filter, order), pageNumber, pageSize);
			if (customers.Count == 0)
			{
				return NoContent();
			}
			return Ok(PaginatedList<GetUserDTO>.CreateAsync(await userService.GetAllCustomerAsync(filter, order), pageNumber, pageSize));
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin,Employee")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var isDelete = await this.userService.Delete(id);
			if (isDelete == false)
			{
				return NotFound();
			}

			return Ok("User is delete.");
		}
	}
}
