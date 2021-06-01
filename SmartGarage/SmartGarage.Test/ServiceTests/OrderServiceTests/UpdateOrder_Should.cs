using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.UpdateDTOs;
using System;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
    //[TestClass]
    //public class UpdateOrder_Should
    //{
    //    [TestMethod]
    //    public async Task UpdateOrder_When_ParamsAreValid()
    //    {
    //        //Arrange
    //        var options = Util.GetOptions(nameof(UpdateOrder_When_ParamsAreValid));
    //        var orderToUpdate = new UpdateOrderDTO
    //        {
    //            FinishDate = DateTime.Now,
    //            GarageId = 1,
    //            OrderStatusId = 3,
    //            VehicleId = 1
    //        };

    //        using (var arrCtx = new SmartGarageContext(options))
    //        {
    //            arrCtx.SeedData();
    //            await arrCtx.SaveChangesAsync();
    //        }

    //        //Act
    //        using (var actCtx = new SmartGarageContext(options))
    //        {
    //            var sut = new OrderService(actCtx);
    //            var result = await sut.UpdateAsync(1, orderToUpdate);
    //            var test = actCtx.Orders.Find(1);

    //            //Assert
    //            Assert.IsTrue(result);
    //            Assert.AreEqual(test.OrderStatusId, 3);
    //        }
    //    }

    //    [TestMethod]
    //    public async Task Return_False_When_IsDeleted()
    //    {
    //        //Arrange
    //        var options = Util.GetOptions(nameof(Return_False_When_IsDeleted));
    //        var orderToUpdate = new UpdateOrderDTO
    //        {
    //            FinishDate = DateTime.Now,
    //            GarageId = 1,
    //            OrderStatusId = 3,
    //            VehicleId = 1
    //        };

    //        using (var arrCtx = new SmartGarageContext(options))
    //        {
    //            arrCtx.SeedData();
    //            await arrCtx.SaveChangesAsync();
    //        }

    //        //Act
    //        using (var actCtx = new SmartGarageContext(options))
    //        {
    //            var test = actCtx.Orders.Find(1);
    //            test.IsDeleted = true;
    //            var sut = new OrderService(actCtx);
    //            var result = await sut.UpdateAsync(1, orderToUpdate);

    //            //Assert
    //            Assert.IsFalse(result);

    //        }
    //    }

    //    [TestMethod]
    //    public async Task Return_False_When_ParamsAreNull()
    //    {
    //        //Arrange
    //        var options = Util.GetOptions(nameof(Return_False_When_ParamsAreNull));
    //        var orderToUpdate = new UpdateOrderDTO
    //        {

    //        };

    //        using (var arrCtx = new SmartGarageContext(options))
    //        {
    //            arrCtx.SeedData();
    //            await arrCtx.SaveChangesAsync();
    //        }

    //        //Act
    //        using (var actCtx = new SmartGarageContext(options))
    //        {
    //            var test = actCtx.Orders.Find(1);
    //            test.IsDeleted = true;
    //            var sut = new OrderService(actCtx);
    //            var result = await sut.UpdateAsync(1, orderToUpdate);

    //            //Assert
    //            Assert.IsFalse(result);

    //        }
    //    }
    //}
}
