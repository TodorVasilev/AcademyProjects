using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.ServiceContracts;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.OrderServiceTests
{
	[TestClass]
	public class DeleteOrder_Should
	{

		[TestClass]
		public class CreateOrder_Should
		{
			[TestMethod]
			public async Task DeleteOrder_When_ParamsAreValid()
			{
				//Arrange
				var options = Util.GetOptions(nameof(DeleteOrder_When_ParamsAreValid));
				var currencyServiceFake = new Mock<ICurrencyService>();
				var userHelperMock = new Mock<IUserHelper>();
				var vehicleServiceMock = new Mock<IVehicleService>();
				var emailServiceMock = new Mock<IEmailsService>();

				using (var arrCtx = new SmartGarageContext(options))
				{
					arrCtx.SeedData();
					await arrCtx.SaveChangesAsync();
				}

				//Act
				using (var actCtx = new SmartGarageContext(options))
				{

					var sut = new OrderService(actCtx,
						currencyServiceFake.Object,
						userHelperMock.Object,
						vehicleServiceMock.Object,
						emailServiceMock.Object);

					var result = await sut.DeleteAsync(2);
					var order = actCtx.Orders.FirstOrDefault(o => o.Id == 2);


					//Assert
					Assert.IsTrue(order.IsDeleted);
				}
			}

			[TestMethod]
			public async Task Return_False_When_NotFound()
			{
				//Arrange
				var options = Util.GetOptions(nameof(Return_False_When_NotFound));

				var currencyServiceFake = new Mock<ICurrencyService>();
				var userHelperMock = new Mock<IUserHelper>();
				var vehicleServiceMock = new Mock<IVehicleService>();
				var emailServiceMock = new Mock<IEmailsService>();
				using (var arrCtx = new SmartGarageContext(options))
				{
					arrCtx.SeedData();
					await arrCtx.SaveChangesAsync();
				}

				//Act
				using (var actCtx = new SmartGarageContext(options))
				{
					var sut = new OrderService(actCtx,
				currencyServiceFake.Object,
				userHelperMock.Object,
				vehicleServiceMock.Object,
				emailServiceMock.Object);
					var result = await sut.DeleteAsync(3);

					//Assert
					Assert.IsFalse(result);
				}
			}

			[TestMethod]
			public async Task Return_False_When_AlreadyDeleted()
			{
				//Arrange
				var options = Util.GetOptions(nameof(Return_False_When_AlreadyDeleted));
				var currencyServiceFake = new Mock<ICurrencyService>();
				var userHelperMock = new Mock<IUserHelper>();
				var vehicleServiceMock = new Mock<IVehicleService>();
				var emailServiceMock = new Mock<IEmailsService>();

				using (var arrCtx = new SmartGarageContext(options))
				{
					arrCtx.SeedData();
					await arrCtx.SaveChangesAsync();
					var order = arrCtx.Orders.FirstOrDefault(o => o.Id == 2);
					order.IsDeleted = true;
					await arrCtx.SaveChangesAsync();
				}

				//Act
				using (var actCtx = new SmartGarageContext(options))
				{
					var sut = new OrderService(actCtx,
				currencyServiceFake.Object,
				userHelperMock.Object,
				vehicleServiceMock.Object,
				emailServiceMock.Object);
					var result = await sut.DeleteAsync(2);
					//Assert
					Assert.IsFalse(result);
				}
			}
		}
	}
}
