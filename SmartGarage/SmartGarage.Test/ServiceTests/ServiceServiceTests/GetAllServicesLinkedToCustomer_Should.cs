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
    public class GetAllServicesLinkedToCustomer_Should
    {
        [TestMethod]
        public async Task ReturnAllServicesLinkedToCustomer()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllServicesLinkedToCustomer));
            var pagination = new PaginationQueryObject();
            var filterObject = new CustomerServicesFilterQueryObject();
            var userId = 3;
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.ServiceOrders
                    .Where(so => so.Order.Vehicle.User.Id == userId)
                    .Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAllLinkedToCustomer(filterObject, userId);

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result.First(), typeof(GetServiceDTO));
            }
        }
    }
}
