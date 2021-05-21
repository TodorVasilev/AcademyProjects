using Microsoft.AspNetCore.Identity;
using SmartGarage.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Helpers
{
    public interface IUserManagerWrapper
    {
        
        Task<IdentityResult> RemoveFromRoleAsync(User user, string role);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<IList<string>> GetRolesAsync(User user);
    }
}