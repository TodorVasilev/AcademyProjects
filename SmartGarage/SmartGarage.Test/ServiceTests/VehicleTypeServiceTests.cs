using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests
{
    [TestClass]
    public class VehicleTypeServiceTests
    {
        [TestMethod]
        public async Task ReturnAllVehicleTypes()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllVehicleTypes));
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.VehicleTypes.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleTypeService(actCtx);
                var result = await sut.GetAll();

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result.First(), typeof(VehicleType));
            }
        }
    }
}
