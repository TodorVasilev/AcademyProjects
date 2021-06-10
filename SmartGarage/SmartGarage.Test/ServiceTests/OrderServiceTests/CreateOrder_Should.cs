using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.ServiceContracts;
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
                FirstName = "First",
                LastName = "Customer",
                UserName = "TheVeryFirstCustomer",
                Address = "Sofia, Bulgaria",
                Age = 28,
                Email = "firstcustomer@gmail.com",
                DrivingLicenseNumber = "13302343",
                PhoneNumber = "087123456",
                GarageName = "Insomnia",
                Colour = "Black",
                NumberPlate = "CA 2011 OC",
                VehicleModelId = 11,
                VIN = "1HGCM82633A004352"
            };
            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperFakeMock = new Mock<IUserHelper>();
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
                var sut = new OrderService(actCtx,
                currencyServiceFake.Object,
                userHelperFakeMock.Object,
                vehicleServiceMock.Object,
                emailServiceMock.Object);
                var result = await sut.CreateAsync(orderToAdd);

                //Assert
                Assert.IsTrue(result);

            }
        }

        [TestMethod]
        public async Task Return_False_When_WrongCareIsChoosen()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_False_When_WrongCareIsChoosen));
            var orderToAdd = new CreateOrderDTO()
            {

                FirstName = "First",
                LastName = "Customer",
                UserName = "TheVeryFirstCustomer",
                Address = "Sofia, Bulgaria",
                Age = 28,
                Email = "firstcustomer@gmail.com",
                DrivingLicenseNumber = "13302343",
                PhoneNumber = "087123456",
                GarageName = "Insomnia",
                Colour = "Red",
                NumberPlate = "E 3994 AC",
                VehicleModelId = 8,
                VIN = "1HGCM82633A004352",
            };

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperFakeMock = new Mock<IUserHelper>();
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
                var sut = new OrderService(actCtx,
                currencyServiceFake.Object,
                userHelperFakeMock.Object,
                vehicleServiceMock.Object,
                emailServiceMock.Object);

                var result = await sut.CreateAsync(orderToAdd);
                //Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task Return_False_When_GarageIsWrong()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Return_False_When_GarageIsWrong));
            var orderToAdd = new CreateOrderDTO()
            {

                FirstName = "First",
                LastName = "Customer",
                UserName = "TheVeryFirstCustomer",
                Address = "Sofia, Bulgaria",
                Age = 28,
                Email = "firstcustomer@gmail.com",
                DrivingLicenseNumber = "13302343",
                PhoneNumber = "087123456",
                GarageName = "",
                Colour = "Red",
                NumberPlate = "E 3994 AC",
                VehicleModelId = 8,
                VIN = "1HGCM82633A004352",
            };

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperFakeMock = new Mock<IUserHelper>();
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
                var sut = new OrderService(actCtx,
                currencyServiceFake.Object,
                userHelperFakeMock.Object,
                vehicleServiceMock.Object,
                emailServiceMock.Object);

                var result = await sut.CreateAsync(orderToAdd);
                //Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task Create_New_VehicleWhenThereIsNo_Such_Vehicle()
        {
            //Arrange
            var options = Util.GetOptions(nameof(Create_New_VehicleWhenThereIsNo_Such_Vehicle));
            var orderToAdd = new CreateOrderDTO()
            {
                FirstName = "First",
                LastName = "Customer",
                UserName = "TheVeryFirstCustomer",
                Address = "Sofia, Bulgaria",
                Age = 28,
                Email = "firstcustomer@gmail.com",
                DrivingLicenseNumber = "13302343",
                PhoneNumber = "087123456",
                GarageName = "Insomnia",
                Colour = "Red",
                NumberPlate = "PR 3994 AC",
                VehicleModelId = 8,
                VIN = "1233245436346",
            };

            Vehicle vehicle = new Vehicle()
            {
                Id = 10,
                Colour = "Red",
                NumberPlate = "PR 3994 AC",
                UserId = 3,
                VehicleModelId = 8,
                VIN = "1233245436346"
            };

            var dummyVehicle = new GetVehicleDTO()
            {
                Id = 10,
                UserId = 3,

            };

            var currencyServiceFake = new Mock<ICurrencyService>();
            var userHelperMock = new Mock<IUserHelper>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var emailServiceMock = new Mock<IEmailsService>();

            vehicleServiceMock.Setup(x => x.CreateAsync(It.IsAny<CreateVehicleDTO>())).Returns(Task.FromResult(dummyVehicle));

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

                var result = await sut.CreateAsync(orderToAdd);
                //Assert
                Assert.IsTrue(result);
                vehicleServiceMock.Verify(x => x.CreateAsync(It.IsAny<CreateVehicleDTO>()), Times.Exactly(1));
            }
        }
    }
}
