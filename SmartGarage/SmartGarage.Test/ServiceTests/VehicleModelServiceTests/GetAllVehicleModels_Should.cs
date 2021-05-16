using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.QueryObjects;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class GetAllVehicleModels_Should
    {
        [TestMethod]
        public async Task ReturnAllVehicleModels()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllVehicleModels));
            var pagination = new PaginationQueryObject();
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.VehicleModels.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.GetAllAsync(pagination);

                //Assert
                Assert.AreEqual(count, result.Count);
                Assert.IsInstanceOfType(result.ItemsColection[0], typeof(GetVehicleModelDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoVehicleModels()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoVehicleModels));
            var pagination = new PaginationQueryObject();

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.GetAllAsync(pagination);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
