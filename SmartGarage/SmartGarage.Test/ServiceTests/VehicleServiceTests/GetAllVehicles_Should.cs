using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartGarage.Data;
using SmartGarage.Service;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.QueryObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Test.ServiceTests.VehicleServiceTests
{
    [TestClass]
    public class GetAllVehicles_Should
    {
        [TestMethod]
        public async Task ReturnAllVehicles_When_NoUserNameIsGiven()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllVehicles_When_NoUserNameIsGiven));
            string customerName = null;
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.Vehicles.Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = sut.GetAll(customerName);

                //Assert
                Assert.AreEqual(count, result.Result.Count);
                Assert.IsInstanceOfType(result.Result[0], typeof(GetVehicleDTO));
            }
        }

        [TestMethod]
        public async Task ReturnAllVehicles_Which_BelongToSpecificCustomer()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnAllVehicles_Which_BelongToSpecificCustomer));
            string customeUserrName = "LoveToAct";
            var count = 0;

            using (var arrCtx = new SmartGarageContext(options))
            {
                arrCtx.SeedData();
                await arrCtx.SaveChangesAsync();
                count = arrCtx.Vehicles
                    .Where(v => v.User.UserName == customeUserrName)
                    .Where(v => !v.IsDeleted)
                    .Count();
            }

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.GetAll(customeUserrName);

                //Assert
                Assert.AreEqual(count, result.Count());
                Assert.IsInstanceOfType(result.First(), typeof(GetVehicleDTO));
            }
        }

        [TestMethod]
        public async Task ReturnNull_When_ThereAreNoVehicles()
        {
            //Arrange
            var options = Util.GetOptions(nameof(ReturnNull_When_ThereAreNoVehicles));
            string customeUserrName = "LoveToAct";

            //Act
            using (var actCtx = new SmartGarageContext(options))
            {
                var sut = new VehicleService(actCtx);
                var result = await sut.GetAll(customeUserrName);

                //Assert
                Assert.IsNull(result);
            }
        }
    }
}
