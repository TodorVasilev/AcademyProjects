using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class UpdateVehicleModel_Should
    {
        [TestMethod]
        public async Task UpdateVehicleModel_When_VehicleModelExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateVehicleModel_When_VehicleModelExists));
            var updateInfo = new VehicleModelDTO
            {
                Name = "E31"
            };
            var vehicleModelId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var vehicleModelToUpdate = await arrCtx.VehicleModels
                    .FirstOrDefaultAsync(v => v.Id == vehicleModelId);

                vehicleModelToUpdate.Name = updateInfo.Name;
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleModelId);

                //Assert
                Assert.AreEqual(updateInfo.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(GetVehicleModelDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_VehicleModelDoesNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_VehicleModelDoesNotExist));
            var updateInfo = new VehicleModelDTO
            {
                Name = "E31"
            };
            var vehicleModelId = -1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var vehicleToUppdate = await arrCtx.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == vehicleModelId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleModelId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
