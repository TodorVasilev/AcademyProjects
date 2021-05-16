using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.Shared;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ManufacturerModelServiceTests
{
    [TestClass]
    public class CreateManufacturer_Should
    {
        [TestMethod]
        public async Task CreateManufacturer_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(CreateManufacturer_When_ParamsAreValid));
            var manufacturerToAdd = new Manufacturer
            {
                Name = "BMW"
            };
            var manufacturerDTO = new ManufacturerDTO(manufacturerToAdd);

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.CreateAsync(manufacturerDTO);

                //Assert
                Assert.AreEqual(manufacturerToAdd.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(ManufacturerDTO));
            }
        }
    }
}
