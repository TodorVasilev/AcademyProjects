using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Api_Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
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

            var user = await this.userService.AuthenticateAsync(loginDTO);

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
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDTO createUserDTO)

        {
           var operationResult = await this.userService.CreateUserAsync(createUserDTO);
            if (operationResult.Succeeded)
            {
                return Ok(new { message = "User created!" });
            }
            return BadRequest(new { message = "Unable to create user!" });
        }
    }
}
