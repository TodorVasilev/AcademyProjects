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
        Task<bool> UpdateAdminAsync(int id, string role);
        Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);
        Task<List<GetUserDTO>> GetAllCustomerAsync(UserSevicesFilterQueryObject filter, UserOrderQueryObject order);
    }
}
