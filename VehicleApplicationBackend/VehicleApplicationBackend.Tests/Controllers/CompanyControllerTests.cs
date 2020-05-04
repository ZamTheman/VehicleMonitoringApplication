using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using VehicleApplicationBackend.Controllers;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Services;
using Microsoft.Extensions.Logging;

namespace VehicleApplicationBackend.Tests.Controllers
{
    [TestFixture]
    public class CompanyControllerTests
    {
        [Test]
        public void GetAllCompanies_ReturnsListOfCompanies()
        {
            var mockService = new Mock<ICompanyService>();
            mockService
                .Setup(service => service.GetAllCompanies())
                .Returns(
                    new List<Company>
                    {
                        new Company { Id = 1, City = "Västerås", Name = "MyCoolCompany", PostalCode = 11111, Street = "MyCoolStreet" },
                        new Company { Id = 2, City = "Örebro", Name = "MyNotSoCoolCompany", PostalCode = 22222, Street = "MyNotSoCoolStreet" }
                    });
            var mockLogger = new Mock<ILogger<CompanyController>>();
            var controller = new CompanyController(mockService.Object, mockLogger.Object);

            var result = controller.Companies();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual("Västerås", result[0].City);
            Assert.AreEqual("MyCoolCompany", result[0].Name);
            Assert.AreEqual(11111, result[0].PostalCode);
            Assert.AreEqual("MyCoolStreet", result[0].Street);
        }
    }
}
