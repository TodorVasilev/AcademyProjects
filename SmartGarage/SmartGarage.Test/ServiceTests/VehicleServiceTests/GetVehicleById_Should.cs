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

namespace SmartGarage.Test.ServiceTests.VehicleServiceTests
{
    [TestClass]
    public class GetVehicleById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectVehicleWithSpecificId()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnCorrectVehicleWithSpecificId));
            var vehicleId = 4;
            var vehicle = new Vehicle();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                vehicle = await arrCtx.Vehicles
                    .FirstOrDefaultAsync(v => v.Id == vehicleId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.GetAsync(vehicleId);

                //Assert
                Assert.AreEqual(vehicle.Colour, result.Colour);
                Assert.AreEqual(vehicle.UserId, result.UserId);
                Assert.IsInstanceOfType(result, typeof(GetVehicleDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_VehicleDoesNotExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_VehicleDoesNotExists));
            var vehicleId = -1;
            var vehicle = new Vehicle();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.GetAsync(vehicleId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
