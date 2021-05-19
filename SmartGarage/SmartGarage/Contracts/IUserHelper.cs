using Microsoft.AspNetCore.Identity;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Contracts
{
    public interface IUserHelper
    {
        Task<IdentityResult> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<UserAuthDTO> AuthenticateAsync(LoginDTO loginDTO);
    }
}
