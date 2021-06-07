using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleServiceTests
{
    [TestClass]
    public class CreateVehicle_Should
    {
        [TestMethod]
        public async Task CreateVehicle_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(CreateVehicle_When_ParamsAreValid));
            var vehicleToAdd = new CreateVehicleDTO
            {
                Colour = "Red",
                NumberPlate = "E 3994 AC",
                UserId = 4,
                VehicleModelId = 8,
                VIN = "1HGCM82633A004352"
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.CreateAsync(vehicleToAdd);

                //Assert
                Assert.AreEqual(vehicleToAdd.Colour, result.Colour);
                Assert.IsInstanceOfType(result, typeof(GetVehicleDTO));
            }
        }
    }
}
