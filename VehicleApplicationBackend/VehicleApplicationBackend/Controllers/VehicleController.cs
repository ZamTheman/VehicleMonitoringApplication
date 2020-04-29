using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleService vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public List<Vehicle> Vehicles()
        {
            return vehicleService.GetAllVehicles();
        }


        [HttpPost]
        public bool Vehicles(string Vin)
        {
            return true;
        }
    }
}