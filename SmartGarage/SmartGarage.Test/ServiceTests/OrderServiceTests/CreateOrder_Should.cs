using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class CreateOrder_Should
    {
        [TestMethod]
        public async Task CreateOrder_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(CreateOrder_When_ParamsAreValid));
            var orderToAdd = new CreateOrderDTO
            {
                ArrivalDate = DateTime.Now,
                GarageId = 1,
                OrderStatusId = 1,
                VehicleId = 1
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new OrderService(actCtx);
                var result = await sut.CreateAsync(orderToAdd);

                //Assert
                Assert.AreEqual(result.Id, 3);
                Assert.IsInstanceOfType(result, typeof(GetOrderDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_NoInput()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_NoInput));
            var orderToAdd = new CreateOrderDTO()
            {

            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new OrderService(actCtx);
                var result = await sut.CreateAsync(orderToAdd);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
