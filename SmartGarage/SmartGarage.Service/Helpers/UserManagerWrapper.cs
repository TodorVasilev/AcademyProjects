using Microsoft.AspNetCore.Identity;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Service.Helpers
{
	public class UserManagerWrapper : IUserManagerWrapper
	{
		private readonly UserManager<User> userManager;

		public UserManagerWrapper(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}

		public async Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
		{
			return await this.userManager.RemoveFromRoleAsync(user, role);
		}
		public async Task<IdentityResult> AddToRoleAsync(User user, string role)
		{
			return await this.userManager.AddToRoleAsync(user, role);
		}

		public async Task<IList<string>> GetRolesAsync(User user)
		{
			return await this.userManager.GetRolesAsync(user);
		}

		public async Task<User> FindByNameAsync(string userName)
		{
			return await this.userManager.FindByNameAsync(userName);
		}

	}
}
