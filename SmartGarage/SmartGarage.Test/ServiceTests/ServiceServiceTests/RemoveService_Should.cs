using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class RemoveService_Should
    {
        [TestMethod]
        public async Task ReturnTrue_When_ServiceIsDeleted()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnTrue_When_ServiceIsDeleted));
            var serviceId = 1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.RemoveAsync(serviceId);

                //Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnTrue_When_ServiceDoesNotExists()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnTrue_When_ServiceDoesNotExists));
            var serviceId = -1;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.RemoveAsync(serviceId);

                //Assert
                Assert.IsFalse(result);
            }
        }
    }
}
