using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
    [TestClass]
    public class Delete_Should
    {

        [TestClass]
        public class UpdateAdmin_Should
        {

            [TestMethod]
            public async Task DeleteUser_WhenParamsAreValid()
            {
                //Arrange
                var options = Util.GetOptions(nameof(DeleteUser_WhenParamsAreValid));
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
                    var result = await sut.Delete(id);
                    var userToCompare = await actCtx.Users.FindAsync(id);

                    //Assert
                    Assert.IsTrue(userToCompare.IsDeleted);

                }
            }

            [TestMethod]
            public async Task Return_False_When_NoUserWithId()
            {
                //Arrange
                var options = Util.GetOptions(nameof(Return_False_When_NoUserWithId));
                int id = 26;
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
                    var result = await sut.Delete(id);

                    //Assert
                    Assert.IsFalse(result);
                }
            }

            [TestMethod]
            public async Task Retrun_False_WhenAlreadyDeleted()
            {
                //Arrange
                var options = Util.GetOptions(nameof(Retrun_False_WhenAlreadyDeleted));
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
                    var userToCompare = await actCtx.Users.FindAsync(id);
                    userToCompare.IsDeleted = true;
                    var result = await sut.Delete(id);

                    //Assert
                    Assert.IsFalse(result);
                }
            }


        }
    }
}
