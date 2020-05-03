using System.Collections.Generic;
using VehicleApplicationBackend.ResponseObjects;

namespace VehicleApplicationBackend.Services
{
    public interface IVehicleService
    {
        List<ResponseVehicle> GetAllVehicles();

        void UpdateVehicleConnectionStatusByVin(string vin);
    }
}
