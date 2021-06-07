using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ManufacturerServiceTests
{
    [TestClass]
    public class GetAllManufacturers_Should
    {
        [TestMethod]
        public async Task ReturnAllManufacturers()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllManufacturers));
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.Manufacturers.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAll();

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result.First(), typeof(GetManufacturerDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoManufacturers()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoManufacturers));

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAll();

                //Assert
                Assert.AreEqual(result.Count(), 0);
            }
        }
    }
}
