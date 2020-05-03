using System;

namespace VehicleApplicationBackend.ResponseObjects
{
    public class ResponseVehicle
    {
        public string Vin { get; set; }
        public int CompanyId { get; set; }
        public string RegistrationNumber { get; set; }
        public double LastCommunicated { get; set; }
    }
}
