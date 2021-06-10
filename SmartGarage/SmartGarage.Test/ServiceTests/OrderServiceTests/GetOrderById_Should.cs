using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class GetOrderById_Should
    {
        [TestMethod]
        public async Task GetExactOrders_Withouth_DeletedOne_Admin()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetExactOrders_Withouth_DeletedOne_Admin));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var orderToAdd = new Order
            {
                Id = 3,
                ArrivalDate = DateTime.Now,
                GarageId = 1,
                OrderStatusId = 1,
                VehicleId = 1,
                IsDeleted = false,
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.AddRangeAsync(orderToAdd);
                await arrCtx.SaveChangesAsync();

            }
            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var adminUser = actCtx.Users.Find(1);

                var sut = new OrderService(actCtx,
                 currencyServiceFake.Object,
                 userHelperMock.Object,
                 vehicleServiceMock.Object,
                 emailServiceMock.Object);

                var result = await sut.GetAsync(3, adminUser);

                //Assert
                Assert.AreEqual(result.Id, 3);
                Assert.IsInstanceOfType(result, typeof(GetOrderDTO));
            }
        }

        [TestMethod]
        public async Task GetAllOrders_ForTheUserInLogin_Withouth_DeletedOne()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_ForTheUserInLogin_Withouth_DeletedOne));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var orderToAdd = new Order
            {
                Id = 3,
                ArrivalDate = DateTime.Now,
                GarageId = 1,
                OrderStatusId = 1,
                VehicleId = 1,
                IsDeleted = false,
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.AddRangeAsync(orderToAdd);
                await arrCtx.SaveChangesAsync();

            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var user = actCtx.Users.Find(5);

                var sut = new OrderService(actCtx,
                 currencyServiceFake.Object,
                 userHelperMock.Object,
                 vehicleServiceMock.Object,
                 emailServiceMock.Object);

                //Assert
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetAsync(3, user));
            }
        }


        [TestMethod]
        public async Task Return_Null_When_OrderNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_Null_When_OrderNotExist));

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var adminUser = actCtx.Users.Find(1);

                var sut = new OrderService(actCtx,
             currencyServiceFake.Object,
             userHelperMock.Object,
             vehicleServiceMock.Object,
             emailServiceMock.Object);

                var result = await sut.GetAsync(3, adminUser);

                //Assert
                Assert.IsNull(result);
            }
        }


        [TestMethod]
        public async Task Calculated_Price_InOrder()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Calculated_Price_InOrder));

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var orderToAdd = new Order
            {
                Id = 3,
                ArrivalDate = DateTime.Now,
                GarageId = 1,
                OrderStatusId = 3,
                VehicleId = 1,
                IsDeleted = false,
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.AddRangeAsync(orderToAdd);
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var adminUser = actCtx.Users.Find(1);

                var sut = new OrderService(actCtx,
             currencyServiceFake.Object,
             userHelperMock.Object,
             vehicleServiceMock.Object,
             emailServiceMock.Object);

                var result = await sut.GetAsync(3, adminUser);

                //Assert

                currencyServiceFake.Verify(x => x.Convert(It.IsAny<DateTime>(), It.IsAny<string>()), Times.Exactly(1));
            }
        }
    }
}
