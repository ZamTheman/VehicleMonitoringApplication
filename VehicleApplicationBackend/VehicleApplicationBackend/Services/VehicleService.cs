using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Repositories;
using VehicleApplicationBackend.ResponseObjects;

namespace VehicleApplicationBackend.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public List<ResponseVehicle> GetAllVehicles() {
            var vehicles = vehicleRepository.GetAllVehicles();
            var responseVechicles = new List<ResponseVehicle>();
            foreach (var vehicle in vehicles){
                responseVechicles.Add(
                    new ResponseVehicle {
                        Vin = vehicle.Vin,
                        RegistrationNumber = vehicle.RegistrationNumber,
                        CompanyId = vehicle.CompanyId,
                        LastCommunicated = vehicle.LastCommunicated.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds
                    }
                );
            }

            return responseVechicles;
        }

        public void UpdateVehicleConnectionStatusByVin(string vin) => vehicleRepository.UpdateVehicleConnectionStatusByVin(DateTime.UtcNow, vin);
    }
}
