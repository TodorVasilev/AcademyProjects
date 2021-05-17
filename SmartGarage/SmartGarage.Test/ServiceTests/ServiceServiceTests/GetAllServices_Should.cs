using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
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
    public class GetAllServices_Should
    {
        [TestMethod]
        public async Task ReturnAllServices()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllServices));
            var pagination = new PaginationQueryObject();
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
                var result = await sut.GetAllAsync(pagination, filterObject);

                //Assert
                Assert.AreEqual(count, result.Count);
                Assert.IsInstanceOfType(result.ItemsColection[0], typeof(GetServiceDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoServices()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoServices));
            var pagination = new PaginationQueryObject();
            var filterObject = new ServiceFilterQueryObject();

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ServiceService(actCtx);
                var result = await sut.GetAllAsync(pagination,filterObject);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
