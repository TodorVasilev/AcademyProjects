﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.QueryObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.ManufacturerServiceTests
{
    [TestClass]
    public class GetAllManufacturers_Should
    {
        [TestMethod]
        public async Task ReturnAllManufacturers()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllManufacturers));
            var pagination = new PaginationQueryObject();
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.Manufacturers.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAllAsync(pagination);

                //Assert
                Assert.AreEqual(count, result.Count);
                Assert.IsInstanceOfType(result.ItemsColection[0], typeof(GetManufacturerDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoManufacturers()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoManufacturers));
            var pagination = new PaginationQueryObject();

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new ManufacturerService(actCtx);
                var result = await sut.GetAllAsync(pagination);

                //Assert
                Assert.AreEqual(result.ItemsOnPage, 0);
                Assert.AreEqual(result.Count, 0);
            }
        }
    }
}
