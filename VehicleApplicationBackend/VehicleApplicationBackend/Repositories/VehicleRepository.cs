using MySql.Data.MySqlClient;
using System.Collections.Generic;
using VehicleApplicationBackend.Dto;
using Dapper;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace VehicleApplicationBackend.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ILogger<VehicleRepository> logger;

        public VehicleRepository(ILogger<VehicleRepository> logger)
        {
            this.logger = logger;
        }

        public List<Vehicle> GetAllVehicles()
        {
            var sql = "SELECT * FROM vehicle";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                try {
                    logger.LogInformation("Fetching all vehicles from db");
                    return con.Query<Vehicle>(sql).ToList();
                }
                catch (Exception e) {
                    logger.LogError($"Failed to fetch all vehicles { e }");
                    return null;
                }
            }
        }

        public void UpdateVehicleConnectionStatusByVin(DateTime connectionTime, string vin)
        {
            var sql = "UPDATE vehicle SET LastCommunicated = @connectionTime WHERE Vin = @vin";

            using (var con = new MySqlConnection(Settings.ConnectionString))
            {
                try {
                    logger.LogInformation($"Updating vehicle with VIN { vin }");
                    con.Execute(sql, new { connectionTime, vin });
                }
                catch (Exception e) {
                    logger.LogError($"Failed to update vehicle with VIN { vin }: { e }");
                }
            }
        }
    }
}
