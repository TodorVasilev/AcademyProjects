using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
    [TestClass]
    public class UpdateAdmin_Should
    {

        //[TestMethod]
        //public async Task UpdateAdmin_WhenParamsAreValid()
        //{
        //    //Arrange
        //    var options = Util.GetOptions(nameof(UpdateAdmin_WhenParamsAreValid));
        //    var role = "Employee";
        //    int id = 4;
        //    var userManagerFake = new Mock<IUserManagerWrapper>();

        //    using (var arrCtx = new SmartGarageContext(options))
        //    {
        //        arrCtx.SeedData();
        //        await arrCtx.SaveChangesAsync();


        //    //    var userFake = await arrCtx.Users.FindAsync(2);
        //      //  userManagerFake.Setup(x => x.GetRolesAsync(It.IsAny<User>())).Callback());
        //    }

        //    //Act
        //    using (var actCtx = new SmartGarageContext(options))
        //    {
        //        var sut = new UserService(actCtx, userManagerFake.Object);
        //        var result = await sut.UpdateAdminAsync(id, role);
        //        var userToCompare = await actCtx.Users.FindAsync(id);

        //        //Assert
        //        Assert.AreEqual(userToCompare.CurrentRole, role);

        //   }

     //   }    
    }
}
