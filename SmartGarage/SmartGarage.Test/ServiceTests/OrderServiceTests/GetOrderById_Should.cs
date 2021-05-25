using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class GetOrderById_Should
    {
        [TestMethod]
        public async Task GetAllOrders_Withouth_DeletedOne()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_Withouth_DeletedOne));
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
                var sut = new OrderService(actCtx);
                var result = await sut.GetAsync(3);

                //Assert
                Assert.AreEqual(result.Id, 3);
                Assert.IsInstanceOfType(result, typeof(GetOrderDTO));
            }
        }

        [TestMethod]
        public async Task Return_Null_When_OrderIsDeleted()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_Null_When_OrderIsDeleted));
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
                var sut = new OrderService(actCtx);
                var result = await sut.GetAsync(3);

                //Assert
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task Return_Null_When_OrderNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_Null_When_OrderNotExist));

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new OrderService(actCtx);
                var result = await sut.GetAsync(3);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
