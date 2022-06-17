using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SerenUP.ApplicationCore.Entitiess;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
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
Model as Model,
Price as Price,
Color as Color
FROM Watch;";
            using var connection = new MySqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query);
        }

        public async Task<Watch> GetById(Guid id)
        {
            const string query = @"
SELECT
Model as Model,
Price as Price,
Color as Color
FROM Watch
WHERE WatchId = @WatchId;";
            using var connection = new MySqlConnection(_connectionstring);
            return await connection.QueryFirstOrDefaultAsync<Watch>(query, new { WatchId = id });
        }

        public async Task<IEnumerable<Watch>> GetWatch(string Model, string Color)
        {
            const string query = @"
SELECT
Model as Model,
Price as Price,
Color as Color
FROM Watch
WHERE Model = @Model && Color = @Color && OrderId IS NULL;";
            using var connection = new MySqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query, new {Model = Model , Color = Color });
        }

        public async Task Insert(Watch model)
        {
            const string query = @"
INSERT INTO Watch (Mode, Price, Color)
VALUES (@model, @Price, @Color)";

            using var connection = new MySqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);
        }

        public async Task Update(Watch model)
        {
             throw new NotImplementedException();
        }
        public async Task Delete(Guid Id)
        {
            const string query = "DELETE FROM Watch WHERE WatchId = @id";

            using var connection = new MySqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id });
        }
    }
}
