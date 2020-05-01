using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Repositories;

namespace VehicleApplicationBackend.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public List<Vehicle> GetAllVehicles() => vehicleRepository.GetAllVehicles();

        public void UpdateVehicleConnectionStatusByVin(string vin) => vehicleRepository.UpdateVehicleConnectionStatusByVin(DateTime.Now, vin);
    }
}
