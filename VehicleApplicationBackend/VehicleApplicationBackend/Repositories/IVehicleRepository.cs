using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Repositories
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        void UpdateVehicleConnectionStatusByVin(DateTime connectionTime, string vin);
    }
}
