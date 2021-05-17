using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class UpdateService_Should
    {
        [TestMethod]
        public async Task UpdateService_When_ServiceExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(UpdateService_When_ServiceExist));
            var updateInfo = new UpdateServiceDTO
            {
                Price = 1.99
            };
            var vehicleId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

                var serviceToUpdate = await arrCtx.Services
                    .FirstOrDefaultAsync(v => v.Id == vehicleId);

                serviceToUpdate.Price = updateInfo.Price;
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleId);

                //Assert
                Assert.AreEqual(result.Price, 1.99);
                Assert.IsInstanceOfType(result, typeof(GetServiceDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ServiceDoesNotExist()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ServiceDoesNotExist));
            var updateInfo = new UpdateServiceDTO
            {
                Price = 1.99
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
                var sut = new ServiceService(actCtx);
                var result = await sut.UpdateAsync(updateInfo, vehicleId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
