using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleServiceTests
{
    [TestClass]
    public class RemoveVehicle_Should
    {
        [TestMethod]
        public async Task RemoveParcel_When_VehicleExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(RemoveParcel_When_VehicleExists));
            var vehicleId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.RemoveAsync(vehicleId);

                //Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task RemoveParcel_When_VehicleDoesNotExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(RemoveParcel_When_VehicleDoesNotExists));
            var vehicleId = -1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.RemoveAsync(vehicleId);

                //Assert
                Assert.IsFalse(result);
            }
        }
    }
}
