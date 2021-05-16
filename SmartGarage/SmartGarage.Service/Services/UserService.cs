using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SmartGarage.Service.DTOs;
using System.Linq;
using SmartGarage.Service.Contracts;

namespace SmartGarage.Service.Services

{
    public class UserService : IUserService
    {
        private readonly SmartGarageContext smartGarageContext;
        private readonly UserManager<User> userManager;
        private readonly IOptions<AppSettings> appSettings;
        private readonly SignInManager<User> signInManager;
        //private readonly RoleManager<IdentityRole<int>> roleManager;

        public UserService(SmartGarageContext smartGarageContext,
            UserManager<User> userManager,
            IOptions<AppSettings> appSettings,
            SignInManager<User> signInManager
            //RoleManager<IdentityRole<int>> roleManager
            )
        {
            this.smartGarageContext = smartGarageContext;
            this.userManager = userManager;
            this.appSettings = appSettings;
            this.signInManager = signInManager;
          //  this.roleManager = roleManager;
        }

        public async Task<UserDTO> AuthenticateAsync(LoginDTO loginDTO)
        {
            var user = await this.smartGarageContext.Users
                .SingleOrDefaultAsync(u => u.UserName == loginDTO.Username);

            // return null if user not found
            if (user != null)
            {
                var signInAttempt = await this.signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

                if (signInAttempt.Succeeded)
                {
                    user.Role = (await this.userManager.GetRolesAsync(user)).FirstOrDefault();

                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);

                    UserDTO result = new UserDTO(user);

                    return result;
                }
            }                     
            return null;
        }
               
    }
}
