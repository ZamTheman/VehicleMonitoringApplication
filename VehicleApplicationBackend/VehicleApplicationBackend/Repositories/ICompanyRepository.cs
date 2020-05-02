using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
    }
}
