using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class GetAvailableServices_Should
    {
        [TestMethod]
        public async Task ReturnCorrectServic_ForSpecificOrder()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnCorrectServic_ForSpecificOrder));
            var order = 1;
            var service = new Data.Models.Service();

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();

            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAvailableServices(order);

                //Assert
                Assert.AreEqual(5, result.Count);
                Assert.IsInstanceOfType(result, typeof(List<GetServiceDTO>));
            }
        }
    }
}
