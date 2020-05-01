using MySql.Data.MySqlClient;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using Dapper;
using System.Linq;
using System;

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

        public void UpdateVehicleConnectionStatusByVin(DateTime connectionTime, string vin)
        {
            var sql = "UPDATE vehicle SET LastCommunicated = @connectionTime WHERE Vin = @vin";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                con.Execute(sql, new { connectionTime, vin });
            }
        }
    }
}
