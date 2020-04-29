using System;

namespace VehicleApplicationBackend.Dto
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public int CompanyId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime LastCommunicated { get; set; }
    }
}
