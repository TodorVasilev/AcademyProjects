using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class GetAllVehicleModels_Should
    {
        [TestMethod]
        public async Task ReturnAllVehicleModels()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllVehicleModels));
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.VehicleModels.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.GetAll();

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result.First(), typeof(GetVehicleModelDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoVehicleModels()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoVehicleModels));

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.GetAll();

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
