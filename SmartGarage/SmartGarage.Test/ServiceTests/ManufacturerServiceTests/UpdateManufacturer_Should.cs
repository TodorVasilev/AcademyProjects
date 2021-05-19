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
    public class UpdateManufacturer_Should
    {
        [TestMethod]
        public async Task ReturnTrue_When_ManufacturerIsUpdated()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnTrue_When_ManufacturerIsUpdated));
            var updateInfo = new ManufacturerDTO
            {
                Name = "BMW"
            };
            var manufacturerId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var vehicleModelToUpdate = await arrCtx.Manufacturers
                    .FirstOrDefaultAsync(v => v.Id == manufacturerId);

                vehicleModelToUpdate.Name = updateInfo.Name;
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, manufacturerId);

                //Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalse_When_ManufacturerDoesNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnFalse_When_ManufacturerDoesNotExist));
            var updateInfo = new ManufacturerDTO
            {
                Name = "BMW"
            };

            var manufacturerId = -1;

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, manufacturerId);

                //Assert
                Assert.IsFalse(result);
            }
        }
    }
}
