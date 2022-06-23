using Dapper;
using Microsoft.Extensions.Configuration;
using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class AccessoryRepository : IAccessoryRepository
    {

        private readonly string _connectionstring;
        public AccessoryRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUpDB");
        }


        public async Task<IEnumerable<Accessory>> GetAll()
        {
            const string query = @"
SELECT
AccessoryId as Id,
Name as Name,
Price as Price,
Description as Description,
Color as Color,
Quantity as Quantity
FROM Accessory;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Accessory>(query);
        }

        public async Task<Accessory> GetById(Guid id)
        {
            const string query = @"
SELECT
AccessoryId as Id,
Name as Name,
Price as Price,
Description as Description,
Color as Color,
Quantity as Quantity
WHERE AccessoryId = @AccessoryId;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryFirstOrDefaultAsync<Accessory>(query, new { AccessoryId = id });
        }
        public async Task<Accessory> GetAccessory(string name, string color)
        {
            const string query = @"
SELECT
Name as Name,
Color as Color
FROM Accessory
WHERE Name = @Name AND Color = @Color;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryFirstOrDefaultAsync<Accessory>(query, new { Name = name, Color = color });

        }

        public async Task Insert(Accessory name)
        {
            const string query = @"
INSERT INTO Accessory (AccessoryId, Name, Price, Description, Color, Quantity)
VALUES (@Id, @Name, @Price, @Description, @Color, @Quantity)";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, name);
        }

        public Task Update(Accessory name)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
