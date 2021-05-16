using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ManufacturerServiceTests
{
    [TestClass]
    public class GetManufacturerById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectManufacturerWithSpecificId()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnCorrectManufacturerWithSpecificId));
            var manufacturerId = 4;
            var manufacturer = new Manufacturer();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                manufacturer = await arrCtx.Manufacturers
                    .FirstOrDefaultAsync(v => v.Id == manufacturerId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAsync(manufacturerId);

                //Assert
                Assert.AreEqual(manufacturer.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(ManufacturerDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ManufacturerDoesNotExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ManufacturerDoesNotExists));
            var manufacturerId = -1;
            var manufacturer = new Manufacturer();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAsync(manufacturerId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
