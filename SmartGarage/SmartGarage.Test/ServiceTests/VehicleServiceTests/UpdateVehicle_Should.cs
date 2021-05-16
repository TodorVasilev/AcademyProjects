using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleServiceTests
{
    [TestClass]
    public class UpdateVehicle_Should
    {
        [TestMethod]
        public async Task UpdateParcel_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateParcel_When_ParamsAreValid));
            var updateInfo = new UpdateVehicleDTO
            {
                Colour = "Transparent"
            };
            var vehicleId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var vehicleToUppdate = await arrCtx.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == vehicleId);

                vehicleToUppdate.Colour = updateInfo.Colour;
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleId);

                //Assert
                Assert.AreEqual(result.Colour, "Transparent");
                Assert.IsInstanceOfType(result, typeof(GetVehicleDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_VehicleDoesntNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_VehicleDoesntNotExist));
            var updateInfo = new UpdateVehicleDTO
            {
                Colour = "Transparent"
            };
            var vehicleId = -1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var vehicleToUppdate = await arrCtx.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == vehicleId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
