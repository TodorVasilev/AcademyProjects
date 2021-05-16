using SmartGarage.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> AuthenticateAsync(LoginDTO loginDTO);
    }
}
