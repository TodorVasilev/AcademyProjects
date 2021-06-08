using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.QueryObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ServiceServiceTests
{
    [TestClass]
    public class GetAllServices_Should
    {
        [TestMethod]
        public async Task ReturnAllServices()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllServices));
            var filterObject = new ServiceFilterQueryObject();
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.Services.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAll(filterObject);

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result[0], typeof(GetServiceDTO));
            }
        }
    }
}
