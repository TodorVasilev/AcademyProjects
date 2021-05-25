using Microsoft.EntityFrameworkCore;
using SmartGarage.Data;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using SmartGarage.Service.ServiceHelpes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Service

{
    public class UserService : IUserService
    {
        private readonly SmartGarageContext context;
        private readonly IUserManagerWrapper userManagerWrapper;

        public UserService(SmartGarageContext context,
            IUserManagerWrapper userManagerWrapper)
        {
            this.context = context;
            this.userManagerWrapper = userManagerWrapper;
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var userToUpdate = await this.context.Users.FindAsync(id);

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

            this.context.Update(userToUpdate);

            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAdminAsync(int id, string role)
        {
            role = role.ToUpper();
            var isRoleExist = this.context.Roles.Any(x => x.NormalizedName == role);
            if (isRoleExist == false)
            {
                throw new ArgumentException("Role does not exist.");
            }

            var userToUpdate = await this.context.Users.FindAsync(id);
            var oldRole = userToUpdate.CurrentRole;
            if (userToUpdate == null || userToUpdate.IsDeleted == true)
            {
                return false;
            }

            userToUpdate.CurrentRole = role ?? userToUpdate.CurrentRole;
            this.context.Update(userToUpdate);

            await this.context.SaveChangesAsync();

            var userRole = (await this.userManagerWrapper.GetRolesAsync(userToUpdate)).FirstOrDefault();
            if (userRole != role)
            {
                await this.userManagerWrapper.RemoveFromRoleAsync(userToUpdate, oldRole);
                await this.userManagerWrapper.AddToRoleAsync(userToUpdate, role);

                return true;
            }

            return false;
        }

        public async Task<List<GetUserDTO>> GetAllCustomerAsync(UserSevicesFilterQueryObject filter, UserOrderQueryObject order)
        {
            var users = this.context.Users
                .Where(u => !u.IsDeleted && u.CurrentRole == "CUSTOMER")
                    .Include(u => u.Vehicles)
                         .ThenInclude(v => v.Orders)
                    .Include(u => u.Vehicles)
                          .ThenInclude(v => v.VehicleModel)
                                 .ThenInclude(m => m.Manufacturer)
                            .AsQueryable();

            if (filter.Name != null)
            {
                users = users.Where(u => u.FirstName.ToUpper().Contains(filter.Name.ToUpper()) || u.LastName.ToUpper().Contains(filter.Name.ToUpper()));
            }

            if (filter.Email != null)
            {
                users = users.Where(u => u.Email.ToUpper().Contains(filter.Email.ToUpper()));
            }

            if (filter.PhoneNumber != null)
            {
                users = users.Where(u => u.PhoneNumber.Contains(filter.PhoneNumber));
            }

            if (filter.Vehicle != null)
            {
                users = users.Where(u => u.Vehicles
                .Where(v => !v.IsDeleted)
                .Any(u => u.VehicleModel.Manufacturer.Name.ToUpper().Contains(filter.Vehicle.ToUpper())));
            }

            if (filter.StartDate != default)
            {
                users = users.Where(u => !u.IsDeleted && u.Vehicles.Any(v => !v.IsDeleted && v.Orders
                     .Any(o => DateTime.Compare(o.ArrivalDate.Date, filter.StartDate.Date) >= 0)));
            }

            if (filter.EndDate != default)
            {
                users = users.Where(u => !u.IsDeleted && u.Vehicles.Any(v => !v.IsDeleted && v.Orders
                       .Any(o => DateTime.Compare(o.ArrivalDate.Date, filter.EndDate.Date) <= 0))); ;
            }

            //Returns null when there is not a service with this id.
            if (users.Count() == 0)
            {
                return null;
            }
            //order the users  
            var usersList = await users.ToListAsync();
            usersList = usersList.SortBy(order.OrderByName, order.OrderByDate);

            var userModelsDTO = usersList
                .Select(x => new GetUserDTO(x))
                .ToList();

            return userModelsDTO;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await this.context.Users.FindAsync(id);

            if (user == null || user.IsDeleted == true)
            {
                return false;
            }

            user.IsDeleted = true;
            this.context.Update(user);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
