using System.Collections.Generic;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Repositories
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
    }
}
