using MySql.Data.MySqlClient;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using Dapper;
using System.Linq;

namespace VehicleApplicationBackend.Repositories
{
    public class VehicleRespository : IVehicleRepository
    {
        public List<Vehicle> GetAllVehicles()
        {
            var sql = "SELECT * FROM vehicle";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                return con.Query<Vehicle>(sql).ToList();
            }
        }
    }
}
