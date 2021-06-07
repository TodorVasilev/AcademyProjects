using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class CreateVehicleModel_Should
    {
        [TestMethod]
        public async Task CreateVehicleModel_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(CreateVehicleModel_When_ParamsAreValid));
            var vehicleToAdd = new VehicleModelDTO
            {
                Name = "E36",
                ManufacturerId = 5,
                VehicleTypeId = 1
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.CreateAsync(vehicleToAdd);

                //Assert
                Assert.AreEqual(vehicleToAdd.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(GetVehicleModelDTO));
            }
        }
    }
}
