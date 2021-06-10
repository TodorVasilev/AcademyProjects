using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.UpdateDTOs;
using SmartGarage.Service.ServiceContracts;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class UpdateOrder_Should
    {
        [TestMethod]
        public async Task UpdateOrder_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateOrder_When_ParamsAreValid));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var orderToUpdate = new UpdateOrderDTO
            {
                OrderStatusId = 3,
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new OrderService(actCtx,
                currencyServiceFake.Object,
                userHelperMock.Object,
                vehicleServiceMock.Object,
                emailServiceMock.Object);

                var result = await sut.UpdateAsync(1, orderToUpdate);
                var test = actCtx.Orders.Find(1);

                //Assert
                Assert.IsTrue(result);
                Assert.AreEqual(test.OrderStatusId, 3);
            }
        }

        [TestMethod]
        public async Task Return_False_When_ThereIsNoOrder()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_False_When_ThereIsNoOrder));

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var orderToUpdate = new UpdateOrderDTO
            {
                OrderStatusId = 2,
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var test = actCtx.Orders.Find(1);

                var sut = new OrderService(actCtx,
                currencyServiceFake.Object,
                userHelperMock.Object,
                vehicleServiceMock.Object,
                emailServiceMock.Object);

                var result = await sut.UpdateAsync(5, orderToUpdate);

                //Assert
                Assert.IsFalse(result);

            }
        }
    }
}
