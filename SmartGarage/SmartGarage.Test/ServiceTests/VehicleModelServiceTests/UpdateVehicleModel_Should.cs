using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.SharedDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class UpdateVehicleModel_Should
    {
        [TestMethod]
        public async Task ReturnTrue_When_VehicleModelIsUpdated()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnTrue_When_VehicleModelIsUpdated));
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
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalse_When_VehicleModelDoesNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnFalse_When_VehicleModelDoesNotExist));
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
                Assert.IsFalse(result);
            }
        }
    }
}
