using System.Collections.Generic;
using VehicleApplicationBackend.Dto;

namespace VehicleApplicationBackend.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
    }
}
