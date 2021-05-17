using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class CreateService_Should
    {
        [TestMethod]
        public async Task CreateService_When_ParamsAreValid()
        {
            //Arrange
            var options = Util.GetOptions(nameof(CreateService_When_ParamsAreValid));
            var service = new CreateServiceDTO
            {
                Name = "Change Oil",
                Price = 149.99
            };

            using (var arrCtx = new SmartGarageContext(options))
            {
                await arrCtx.SaveChangesAsync();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.CreateAsync(service);

                //Assert
                Assert.AreEqual(service.Name, result.Name);
                Assert.IsInstanceOfType(result, typeof(GetServiceDTO));
            }
        }
    }
}
