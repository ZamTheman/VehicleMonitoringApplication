using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Services
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
    }
}
