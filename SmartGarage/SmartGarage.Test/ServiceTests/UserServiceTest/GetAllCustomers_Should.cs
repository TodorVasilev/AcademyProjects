using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
    [TestClass]
    public class GetAllCustomers_Should
    {
        [TestMethod]
        public async Task Return_OnlyCustomer()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_OnlyCustomer));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter, order);

                //Assert
                Assert.AreEqual(result.Count, 3);              
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_No_Customer()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_No_Customer));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();
            filter.Name = "krum";


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter,order);

                //Assert
                Assert.AreEqual(result, null);
            }
        }


        [TestMethod]
        public async Task Return_CorrectByName()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_CorrectByName));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();
            filter.Name = "Ivan";


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter, order);

                //Assert
                Assert.AreEqual(result.Count,1);
            }
        }

        [TestMethod]
        public async Task Return_CorrectByEmail()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_CorrectByEmail));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();
            filter.Email = "Ivan";


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter,order);

                //Assert
                Assert.AreEqual(result.Count, 1);
            }
        }
        [TestMethod]
        public async Task Return_CorrectByPhone()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_CorrectByPhone));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();
            filter.PhoneNumber = "087123456";


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter,order);

                //Assert
                Assert.AreEqual(result.Count, 1);
            }
        }

        [TestMethod]
        public async Task Return_CorrectByVehicleBrand()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_CorrectByVehicleBrand));
            var userManagerFake = new Mock<IUserManagerWrapper>();
            var filter = new UserSevicesFilterQueryObject();
            var order = new UserOrderQueryObject();
            filter.Vehicle = "Tesla";


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new UserService(actCtx, userManagerFake.Object);
                var result = await sut.GetAllCustomerAsync(filter,order);

                //Assert
                Assert.AreEqual(result.Count, 1);
            }
        }

        //[TestMethod]
        //public async Task Return_CorrectByStartDate()
        //{
        //    //Arrange
        //    var options = Util.GetOptions(nameof(Return_CorrectByVehicleBrand));
        //    var userManagerFake = new Mock<IUserManagerWrapper>();
        //    var filter = new UserSevicesFilterQueryObject();
        //    filter.StartDate = DateTime.Now.AddDays(1).Date;
        //    var date = DateTime.Now.AddDays(2).Date.ToString();

        //    using (var arrCtx = new SmartGarageContext(options))
        //    {
        //        arrCtx.SeedData();
        //        await arrCtx.SaveChangesAsync();
        //    }

        //    //Act
        //    using (var actCtx = new SmartGarageContext(options))
        //    {
        //        var sut = new UserService(actCtx, userManagerFake.Object);
        //        var result = await sut.GetAllCustomerAsync(filter);

        //        //Assert
        //        Assert.AreEqual(result.Count, 1);
        //    }
        //}
    }
}
