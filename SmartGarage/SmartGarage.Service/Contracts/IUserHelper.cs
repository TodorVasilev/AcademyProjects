using Microsoft.AspNetCore.Identity;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IUserHelper
    {
        Task<IdentityResult> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<UserAuthDTO> AuthenticateAsync(LoginDTO loginDTO);
    }
}
