using System.Collections.Generic;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetAllVehicles();

        void UpdateVehicleConnectionStatusByVin(string vin);
    }
}
