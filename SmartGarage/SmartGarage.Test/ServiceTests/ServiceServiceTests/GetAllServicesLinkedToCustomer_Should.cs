using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoServicesLinkedToUser()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoServicesLinkedToUser));
            var pagination = new PaginationQueryObject();
            var filterObject = new CustomerServicesFilterQueryObject();
            var userId = 1;

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAllLinkedToCustomer(filterObject, userId);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
