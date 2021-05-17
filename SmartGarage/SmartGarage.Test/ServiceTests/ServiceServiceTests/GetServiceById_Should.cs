using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class GetServiceById_Should
    {
        [TestMethod]
        public async Task ReturnCorrectServiceWithSpecificId()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnCorrectServiceWithSpecificId));
            var serviceId = 4;
            var service = new Data.Models.Service();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                service = await arrCtx.Services
                    .FirstOrDefaultAsync(v => v.Id == serviceId);
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAsync(serviceId);

                //Assert
                Assert.AreEqual(service.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(GetServiceDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ServiceDoesNotExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ServiceDoesNotExists));
            var serviceId = -1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAsync(serviceId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
