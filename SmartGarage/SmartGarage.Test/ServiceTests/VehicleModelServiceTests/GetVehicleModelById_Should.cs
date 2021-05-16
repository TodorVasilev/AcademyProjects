using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleModelServiceTests
{
    [TestClass]
    public class GetVehicleModelById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectVehicleModelWithSpecificId()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnCorrectVehicleModelWithSpecificId));
            var vehicleModelId = 4;
            var vehiclemodel = new VehicleModel();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                vehiclemodel = await arrCtx.VehicleModels
                    .FirstOrDefaultAsync(v => v.Id == vehicleModelId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleModelService(actCtx);
                var result = await sut.GetAsync(vehicleModelId);

                //Assert
                Assert.AreEqual(vehiclemodel.Name, result.Name);
                Assert.AreEqual(vehiclemodel.Manufacturer.Name, result.ManafacturerName);
                Assert.IsInstanceOfType(result, typeof(GetVehicleModelDTO));
            }
        }

        //[TestMethod]
        //public async Task ReturnNull_When_VehicleDoesNotExists()
        //{
        //    //Arrange
        //    var options = Util.GetOptions(nameof(ReturnNull_When_VehicleDoesNotExists));
        //    var vehicleId = -1;
        //    var vehicle = new Vehicle();

        //    using (var arrCtx = new SmartGarageContext(options))
        //    {
        //        arrCtx.SeedData();
        //        await arrCtx.SaveChangesAsync();
        //    }

        //    //Act
        //    using (var actCtx = new SmartGarageContext(options))
        //    {
        //        var sut = new VehicleService(actCtx);
        //        var result = await sut.GetAsync(vehicleId);

        //        //Assert
        //        Assert.IsNull(result);
        //    }
        //}
    }
}
