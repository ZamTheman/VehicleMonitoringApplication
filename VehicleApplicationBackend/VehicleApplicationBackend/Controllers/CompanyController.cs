using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly ILogger<CompanyController> logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            this.companyService = companyService;
            this.logger = logger;
        }

        [HttpGet]
        public List<Company> Companies()
        {
            logger.LogInformation("All companies requested");
            return companyService.GetAllCompanies();
        }
    }
}