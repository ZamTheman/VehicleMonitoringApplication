using System;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace VehicleApplicationBackend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ILogger<CompanyRepository> logger;

        public CompanyRepository(ILogger<CompanyRepository> logger)
        {
            this.logger = logger;
        }

        public List<Company> GetAllCompanies()
        {
            var sql = "SELECT * FROM company";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                try {
                    logger.LogInformation("Fetching all companies from db");
                    return con.Query<Company>(sql).ToList();
                }
                catch (Exception e) {
                    logger.LogError($"Failed to fetch all companies { e }");
                    return null;
                }
            }
        }
    }
}