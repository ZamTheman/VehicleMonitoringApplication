using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using VehicleApplicationBackend.Repositories;

namespace VehicleApplicationBackend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public List<Company> GetAllCompanies() => companyRepository.GetAllCompanies();
    }
}
