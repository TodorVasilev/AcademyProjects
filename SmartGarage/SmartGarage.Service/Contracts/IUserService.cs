using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IUserService
    {
        Task<bool> Delete(int id);
        Task<List<GetUserDTO>> GetAllCustomerAsync(UserSevicesFillterQueryObject filter);
        Task<bool> UpdateAdminAsync(int id, string role);
        Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);
    }
}
