using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleApplicationBackend.ResponseObjects;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleService vehicleService;
        private readonly ILogger<CompanyController> logger;
        
        public VehicleController(IVehicleService vehicleService, ILogger<CompanyController> logger)
        {
            this.vehicleService = vehicleService;
            this.logger = logger;
        }

        [HttpGet]
        public List<ResponseVehicle> Vehicles()
        {
            logger.LogInformation("All vehicles requested");
            return vehicleService.GetAllVehicles();
        }


        [HttpPost]
        public void Vehicles([FromBody] string vin)
        {
            logger.LogInformation($"Update vehicle with VIN: { vin } requested");
            vehicleService.UpdateVehicleConnectionStatusByVin(vin);
        }
    }
}