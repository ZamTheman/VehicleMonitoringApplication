using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using VehicleApplicationBackend.Services;
using VehicleApplicationBackend.Controllers;
using Microsoft.Extensions.Logging;
using VehicleApplicationBackend.ResponseObjects;

namespace VehicleApplicationBackend.Tests.Controlllers
{
    [TestFixture]
    public class VehicleControllerTests
    {
        [Test]
        public void GetAllVehicles_ReturnsListOfVehicles()
        {
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.GetAllVehicles())
                .Returns(
                    new List<ResponseVehicle>
                    {
                        new ResponseVehicle { Vin = "MyVin1", RegistrationNumber = "MyReg1", CompanyId = 1, LastCommunicated = 123456 },
                        new ResponseVehicle { Vin = "MyVin2", RegistrationNumber = "MyReg2", CompanyId = 2, LastCommunicated = 567890 }
                    });
            var mockLogger = new Mock<ILogger<CompanyController>>();
            var controller = new VehicleController(mockService.Object, mockLogger.Object);

            var result = controller.Vehicles();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("MyVin1", result[0].Vin);
            Assert.AreEqual("MyReg1", result[0].RegistrationNumber);
            Assert.AreEqual(1, result[0].CompanyId);
        }

        [Test]
        public void UpdateVehicle_ShouldPassWithoutCrash()
        {
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.UpdateVehicleConnectionStatusByVin("TestVin"));
            var mockLogger = new Mock<ILogger<CompanyController>>();
            var controller = new VehicleController(mockService.Object, mockLogger.Object);

            controller.Vehicles("TestVin");
        }
    }
}
