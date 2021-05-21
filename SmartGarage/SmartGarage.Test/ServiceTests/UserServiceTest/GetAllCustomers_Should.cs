using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
//    [TestClass]
//    public class GetAllCustomers_Should
//    {
//        [TestMethod]
//        public async Task Return_OnlyCustomer()
//        {
//            //Arrange
//            var options = Util.GetOptions(nameof(Return_OnlyCustomer));
//            var userManagerFake = new Mock<IUserManagerWrapper>();

//            using (var arrCtx = new SmartGarageContext(options))
//            {
//                arrCtx.SeedData();
//                await arrCtx.SaveChangesAsync();
//            }

//            //Act
//            using (var actCtx = new SmartGarageContext(options))
//            {
//                var sut = new UserService(actCtx, userManagerFake.Object);
//                var result = await sut.GetAllCustomerAsync(id, userToUpdate);
//                var userToCompare = await actCtx.Users.FindAsync(id);

//                //Assert
//                Assert.IsFalse(result);
//            }
//        }

//    }
}
