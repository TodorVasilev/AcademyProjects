using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Data.Models;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
    [TestClass]
    public class UpdateAdmin_Should
    {

		[TestMethod]
		public async Task UpdateAdmin_WhenParamsAreValid()
		{
			//Arrange
			var options = Util.GetOptions(nameof(UpdateAdmin_WhenParamsAreValid));
			var resultRole = "EMPLOYEE";
			string email = "firstcustomer@gmail.com";
			var userManagerMock = new Mock<IUserManagerWrapper>();
			IList<string> list = new List<string>() { "Customer" };


			using (var arrCtx = new SmartGarageContext(options))
			{
				arrCtx.SeedData();
				await arrCtx.SaveChangesAsync();

				userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>())).Returns(Task.FromResult(list));
			}

			//Act
			using (var actCtx = new SmartGarageContext(options))
			{
				var sut = new UserService(actCtx, userManagerMock.Object);
				var result = await sut.UpdateAdminAsync(email, resultRole);
				var userToCompare = await actCtx.Users.FirstOrDefaultAsync(u=>u.Email==email);

				//Assert
				userManagerMock.Verify(x => x.RemoveFromRoleAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Exactly(1));
				userManagerMock.Verify(x => x.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Exactly(1));
				Assert.AreEqual(userToCompare.CurrentRole, resultRole);
			}

		}
	}
}
