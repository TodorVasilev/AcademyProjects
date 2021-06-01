using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.ServiceContracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service.Helpers
{
	public class UserHelper : IUserHelper
	{
		private readonly SmartGarageContext smartGarageContext;
		private readonly UserManager<User> userManager;
		private readonly IOptions<AppSettings> appSettings;
		private readonly SignInManager<User> signInManager;
		private readonly IEmailsService emailSender;


		public UserHelper(SmartGarageContext context,
			UserManager<User> userManager,
			IOptions<AppSettings> appSettings,
			IEmailsService emailSender,
			SignInManager<User> signInManager
			)
		{
			this.smartGarageContext = context;
			this.userManager = userManager;
			this.appSettings = appSettings;
			this.emailSender = emailSender;
			this.signInManager = signInManager;
		}
		public async Task<UserAuthDTO> AuthenticateAsync(LoginDTO loginDTO)
		{
			var user = await this.smartGarageContext.Users
				.SingleOrDefaultAsync(u => u.UserName == loginDTO.Username);

			// return null if user not found
			if (user != null)
			{
				var signInAttempt = await this.signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

				if (signInAttempt.Succeeded)
				{
					var userRole = (await this.userManager.GetRolesAsync(user)).FirstOrDefault();

					// authentication successful so generate jwt token
					var tokenHandler = new JwtSecurityTokenHandler();
					var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
					var tokenDescriptor = new SecurityTokenDescriptor
					{
						Subject = new ClaimsIdentity(new Claim[]
						{
							new Claim(ClaimTypes.Name, user.UserName),
							new Claim(ClaimTypes.Role, userRole)
						}),
						Expires = DateTime.UtcNow.AddDays(7),
						SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
					};

					var token = tokenHandler.CreateToken(tokenDescriptor);

					UserAuthDTO result = new UserAuthDTO(user);

					result.Token = tokenHandler.WriteToken(token);

					return result;
				}
			}
			return null;
		}

		public async Task<IdentityResult> CreateUserAsync(CreateUserDTO createUserDTO)
		{
			var user = new User
			{
				FirstName = createUserDTO.FirstName,
				LastName = createUserDTO.LastName,
				PhoneNumber = createUserDTO.PhoneNumber,
				Age = createUserDTO.Age,
				DrivingLicenseNumber = createUserDTO.DrivingLicenseNumber,
				Address = createUserDTO.Address,
				UserName = createUserDTO.UserName,
				Email = createUserDTO.Email,
				CurrentRole = "CUSTOMER"
			};
			var passwordLength = 12;
			var password = CreatePassword(passwordLength);

			var result = await userManager.CreateAsync(user, password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, "Customer");

				await emailSender.SendRegistrationEmail(createUserDTO.Email, password);
			}
			return result;
		}

		private string CreatePassword(int length)
		{
			const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			const string ensureIsValid = "aA1";
			StringBuilder res = new StringBuilder();
			Random rnd = new Random();
			while (0 < length--)
			{
				res.Append(valid[rnd.Next(valid.Length)]);
			}
			return res.ToString() + ensureIsValid;
		}
	}
}
