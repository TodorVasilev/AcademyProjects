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
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.ServiceContracts;
using Microsoft.AspNetCore.WebUtilities;
using SmartGarage.Service.DTOs.UpdateDTOs;

namespace SmartGarage.Service

{
    public class UserService : IUserService
    {
        private readonly SmartGarageContext smartGarageContext;


        public UserService(SmartGarageContext smartGarageContext)
        {
            this.smartGarageContext = smartGarageContext;
        }


        public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var userToUpdate = await this.smartGarageContext.Users.FindAsync(id);

            if (userToUpdate == null || userToUpdate.IsDeleted == true)
            {
                return false;
            }
            userToUpdate.UserName = updateUserDTO.UserName ?? userToUpdate.UserName;
            userToUpdate.NormalizedUserName = (updateUserDTO.UserName ?? userToUpdate.NormalizedUserName).ToUpper();
            userToUpdate.FirstName = updateUserDTO.FirstName ?? userToUpdate.FirstName;
            userToUpdate.LastName = updateUserDTO.LastName ?? userToUpdate.LastName;
            if (updateUserDTO.Age != null)
            {
                userToUpdate.Age = (int)updateUserDTO.Age;
            }

            userToUpdate.Address = updateUserDTO.Address ?? userToUpdate.Address;
            userToUpdate.PhoneNumber = updateUserDTO.PhoneNumber ?? userToUpdate.PhoneNumber;
            userToUpdate.DrivingLicenseNumber = updateUserDTO.DrivingLicenseNumber ?? userToUpdate.DrivingLicenseNumber;
            userToUpdate.Email = updateUserDTO.Email ?? userToUpdate.Email;
            userToUpdate.NormalizedEmail = (updateUserDTO.Email ?? userToUpdate.NormalizedEmail).ToUpper();

            this.smartGarageContext.Update(userToUpdate);

            await this.smartGarageContext.SaveChangesAsync();
            return true;
        }




    }
}
