using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.ServiceContracts;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    [TestClass]
    public class AddService_Should
    {
        [TestMethod]
        public async Task AddServiceToOrder()
        {
            //Arrange
            var options = Util.GetOptions(nameof(AddServiceToOrder));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var serviceOrder = new ServiceOrder()
            {
                OrderId = 1,
                ServiceId = 3
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

                var result = await sut.AddService(serviceOrder);
                var orderCountAfterAdd = actCtx.ServiceOrders.Count(o => o.OrderId == 1);

                //Assert
                Assert.AreEqual(orderCountAfterAdd, 2);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public async Task ReturnFalse_WhenOrder_InOrderServiceIsZero()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnFalse_WhenOrder_InOrderServiceIsZero));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var serviceOrder = new ServiceOrder()
            {
                OrderId = 0,
                ServiceId = 3
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

                var result = await sut.AddService(serviceOrder);

                //Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalse_WhenService_InOrderServiceIsZero()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnFalse_WhenService_InOrderServiceIsZero));
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            var serviceOrder = new ServiceOrder()
            {
                OrderId = 1,
                ServiceId = 0
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

                var result = await sut.AddService(serviceOrder);

                //Assert
                Assert.IsFalse(result);
            }
        }
    }
}
