using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Service.Contracts
{
    public interface IUserService
    {

        Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);
    }
}
