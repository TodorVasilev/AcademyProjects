using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.Helpers;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
    [TestClass]
    public class UpdateUser_Should
    {
        [TestMethod]
        public async Task UpdateUser_WhenParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateUser_WhenParamsAreValid));
            var userToUpdate = new UpdateUserDTO();
            userToUpdate.FirstName = "Pesho";
            userToUpdate.Age = 45;
            int id = 4;
            var userManagerFake = new Mock<IUserManagerWrapper>();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.UpdateUserAsync(id, userToUpdate);
                var userToCompare = await actCtx.Users.FindAsync(id);

                //Assert
                Assert.AreEqual(userToCompare.FirstName, userToUpdate.FirstName);
                Assert.AreNotEqual(userToCompare.LastName, userToUpdate.LastName);
            }
        }

        [TestMethod]
        public async Task ReturnFalse_WhenUserNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnFalse_WhenUserNotExist));
            var userToUpdate = new UpdateUserDTO();
            userToUpdate.FirstName = "Pesho";
            int id = 4;
            var userManagerFake = new Mock<IUserManagerWrapper>();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                var userToDelete = await arrCtx.Users.FindAsync(id);
                userToDelete.IsDeleted = true;
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.UpdateUserAsync(id, userToUpdate);
                var userToCompare = await actCtx.Users.FindAsync(id);

                //Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task UpdateUser_Not_ChangeRole()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateUser_Not_ChangeRole));
            var userToUpdate = new UpdateUserDTO();
            userToUpdate.FirstName = "Pesho";
            userToUpdate.Age = 45;
            int id = 4;
            var userManagerFake = new Mock<IUserManagerWrapper>();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();

                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var userBeforeUpdate = await actCtx.Users.FindAsync(id);

                var result = await sut.UpdateUserAsync(id, userToUpdate);
                var userToCompare = await actCtx.Users.FindAsync(id);

                //Assert
                Assert.AreEqual(userToCompare.CurrentRole, userBeforeUpdate.CurrentRole);               
            }
        }
    }
}
