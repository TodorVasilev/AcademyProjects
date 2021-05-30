using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class GettAllOrders_Should
    {
        [TestMethod]
        public async Task GetAllOrders_Withouth_Deleted()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_Withouth_Deleted));
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
               // var result = await sut.GetAll();

                //Assert
            //    Assert.AreEqual(result.Count, 2);
                //Assert.IsInstanceOfType(result, typeof(List<GetOrderDTO>));
            }
        }
        [TestMethod]
        public async Task GetAllOrders_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(GetAllOrders_When_ParamsAreValid));


            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new OrderService(actCtx);
            //    var result = await sut.GetAll();

                //Assert
             //   Assert.AreEqual(result.Count, 2);
             //  Assert.IsInstanceOfType(result, typeof(List<GetOrderDTO>));
            }
        }
    }
}
