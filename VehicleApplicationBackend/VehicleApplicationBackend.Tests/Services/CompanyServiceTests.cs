using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Repositories;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend.Tests.Services
{
    [TestFixture]
    public class CompanyServiceTests
    {
        [Test]
        public void GetAllCompanies_ReturnsListOfCompanies()
        {
            var mockService = new Mock<ICompanyRepository>();
            mockService
                .Setup(repo => repo.GetAllCompanies())
                .Returns(
                    new List<Company>
                    {
                        new Company { Id = 1, City = "Västerås", Name = "MyCoolCompany", PostalCode = 11111, Street = "MyCoolStreet" },
                        new Company { Id = 2, City = "Örebro", Name = "MyNotSoCoolCompany", PostalCode = 22222, Street = "MyNotSoCoolStreet" }
                    });
            var service = new CompanyService(mockService.Object);

            var result = service.GetAllCompanies();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual("Västerås", result[0].City);
            Assert.AreEqual("MyCoolCompany", result[0].Name);
            Assert.AreEqual(11111, result[0].PostalCode);
            Assert.AreEqual("MyCoolStreet", result[0].Street);
        }
    }
}
