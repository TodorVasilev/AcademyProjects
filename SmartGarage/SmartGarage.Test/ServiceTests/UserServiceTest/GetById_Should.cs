using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.UserServiceTest
{
	[TestClass]
	public class GetById_Should
	{
		[TestMethod]
		public async Task Return_CorrectById()
		{
			//Arrange
			var options = Util.GetOptions(nameof(Return_CorrectById));
			var userManagerFake = new Mock<IUserManagerWrapper>();
			var filter = new UserSevicesFilterQueryObject();
			var order = new UserOrderQueryObject();

			using (var arrCtx = new SmartGarageContext(options))
			{
				arrCtx.SeedData();
				await arrCtx.SaveChangesAsync();
			}

			//Act
			using (var actCtx = new SmartGarageContext(options))
			{
				var sut = new UserService(actCtx, userManagerFake.Object);
				var result = await sut.GetById(3);

				//Assert
				Assert.AreEqual("firstcustomer@gmail.com", result.Email);
			}
		}

		[TestMethod]
		public async Task Return_Null_WhenUserIsDeleted()
		{
			//Arrange
			var options = Util.GetOptions(nameof(Return_Null_WhenUserIsDeleted));
			var userManagerFake = new Mock<IUserManagerWrapper>();
			var filter = new UserSevicesFilterQueryObject();
			var order = new UserOrderQueryObject();
			var email = "firstcustomer@gmail.com";

			using (var arrCtx = new SmartGarageContext(options))
			{
				arrCtx.SeedData();
				await arrCtx.SaveChangesAsync();
			}

			//Act
			using (var actCtx = new SmartGarageContext(options))
			{
				var sut = new UserService(actCtx, userManagerFake.Object);

				var userToDelete = await actCtx.Users.FirstOrDefaultAsync(u => u.Email == email);
				userToDelete.IsDeleted = true;

				var result = await sut.GetById(3);

				//Assert
				Assert.IsNull(result);
			}
		}

	}
}
