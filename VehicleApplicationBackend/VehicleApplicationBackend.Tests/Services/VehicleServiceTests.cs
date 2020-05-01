using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Repositories;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend.Tests.Services
{
    [TestFixture]
    public class VehicleServiceTests
    {
        [Test]
        public void GetAllVehicles_ReturnsListOfVehicles()
        {
            var mockService = new Mock<IVehicleRepository>();
            mockService
                .Setup(repo => repo.GetAllVehicles())
                .Returns(
                    new List<Vehicle>
                    {
                        new Vehicle { Vin = "MyVin1", RegistrationNumber = "MyReg1", CompanyId = 1, LastCommunicated = DateTime.Now },
                        new Vehicle { Vin = "MyVin2", RegistrationNumber = "MyReg2", CompanyId = 2, LastCommunicated = DateTime.Now }
                    });
            var service = new VehicleService(mockService.Object);

            var result = service.GetAllVehicles();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("MyVin1", result[0].Vin);
            Assert.AreEqual("MyReg1", result[0].RegistrationNumber);
            Assert.AreEqual(1, result[0].CompanyId);
            Assert.IsTrue(result[0].LastCommunicated < DateTime.Now);
        }

        [Test]
        public void UpdateVehicle_ShouldPassWithoutCrash()
        {
            var mockService = new Mock<IVehicleRepository>();
            mockService
                .Setup(repo => repo.UpdateVehicleConnectionStatusByVin(DateTime.Now, "MyTestVin"));
            var service = new VehicleService(mockService.Object);

            service.UpdateVehicleConnectionStatusByVin("MyTestVin");
        }
    }
}
