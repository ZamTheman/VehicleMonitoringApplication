using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Services;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Controllers;
using Microsoft.Extensions.Logging;

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
                    new List<Vehicle>
                    {
                        new Vehicle { Vin = "MyVin1", RegistrationNumber = "MyReg1", CompanyId = 1, LastCommunicated = DateTime.Now },
                        new Vehicle { Vin = "MyVin2", RegistrationNumber = "MyReg2", CompanyId = 2, LastCommunicated = DateTime.Now }
                    });
            var mockLogger = new Mock<ILogger<CompanyController>>();
            mockLogger.Setup(logger => logger.LogInformation(string.Empty));
            var controller = new VehicleController(mockService.Object, mockLogger.Object);

            var result = controller.Vehicles();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("MyVin1", result[0].Vin);
            Assert.AreEqual("MyReg1", result[0].RegistrationNumber);
            Assert.AreEqual(1, result[0].CompanyId);
            Assert.IsTrue(result[0].LastCommunicated < DateTime.Now);
        }

        [Test]
        public void UpdateVehicle_ShouldPassWithoutCrash()
        {
            var mockService = new Mock<IVehicleService>();
            mockService
                .Setup(service => service.UpdateVehicleConnectionStatusByVin("TestVin"));
            var mockLogger = new Mock<ILogger<CompanyController>>();
            mockLogger.Setup(logger => logger.LogInformation(string.Empty));
            var controller = new VehicleController(mockService.Object, mockLogger.Object);

            controller.Vehicles("TestVin");
        }
    }
}
