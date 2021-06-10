using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class GettAllOrders_Should
    {
        [TestMethod]
        public async Task GetAllOrders_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_When_ParamsAreValid));
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
                IsDeleted = true,
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

                var result = await sut.GetAll(adminUser, default);


                Assert.AreEqual(result.Count, 3);
                Assert.IsInstanceOfType(result, typeof(List<GetOrderDTO>));
            }
        }
        [TestMethod]
        public async Task GetAllOrders_When_Customer()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_When_Customer));

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
                var customer = actCtx.Users.Find(4);

                var sut = new OrderService(actCtx,
                  currencyServiceFake.Object,
                  userHelperMock.Object,
                  vehicleServiceMock.Object,
                  emailServiceMock.Object);

                var result = await sut.GetAll(customer, default);

                Assert.AreEqual(result.Count, 1);
                Assert.IsInstanceOfType(result, typeof(List<GetOrderDTO>));
            }
        }
        [TestMethod]
        public async Task GetAllFilteredOrders_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllFilteredOrders_When_ParamsAreValid));
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
                IsDeleted = true,
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

                var result = await sut.GetAll(adminUser, "first");


                Assert.AreEqual(result.Count, 2);
                Assert.IsInstanceOfType(result, typeof(List<GetOrderDTO>));
            }
        }
    }
}
