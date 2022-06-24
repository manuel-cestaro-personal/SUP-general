using Dapper;
using Microsoft.Extensions.Configuration;
using SerenUP.ApplicationCore.Entitiess;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class WatchRepository : IWatchRepository
    {
        private readonly string _connectionstring;
        public WatchRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUpDB");
        }

        public async Task<IEnumerable<Watch>> GetAll()
        {
            const string query = @"
SELECT
WatchId as Id,
Model as Model,
Price as Price,
MacAddress as MacAddress,
ActivationKey as ActivationKey,
Color as Color
FROM Watch;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query);
        }

        public async Task<Watch> GetById(Guid id)
        {
            throw new NotImplementedException(); ;
        }

        public async Task<IEnumerable<Watch>> GetWatch(string Model, string Color)
        {
            const string query = @"
SELECT
Model as Model,
Price as Price,
Color as Color
FROM Watch
WHERE Model = @Model AND Color = @Color AND OrderId IS NULL;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query, new {Model = Model , Color = Color });
        }

        public async Task Insert(Watch model)
        { 
            const string query = @"
INSERT INTO Watch (WatchId, Model, Price, MacAddress, ActivationKey, Color)
VALUES (@Id, @Model, @Price, @MacAddress, @ActivationKey, @Color)";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);
        }

        public async Task Update(Watch model)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Guid Id)
        {
            const string query = "DELETE FROM Watch WHERE WatchId = @id";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id });
        }
    }
}
