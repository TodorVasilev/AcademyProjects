using Microsoft.AspNetCore.Identity;
using SmartGarage.Service.DTOs;
using SmartGarage.Service.DTOs.CreateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IUserService
    {
        Task<UserAuthDTO> AuthenticateAsync(LoginDTO loginDTO);
        Task<IdentityResult> CreateUserAsync(CreateUserDTO createUserDTO);
    }
}
