using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace VehicleApplicationBackend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public List<Company> GetAllCompanies()
        {
            var sql = "SELECT * FROM Company";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                return con.Query<Company>(sql).ToList();
            }
        }
    }
}
