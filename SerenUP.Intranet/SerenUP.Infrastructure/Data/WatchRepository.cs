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
WatchId,
Model as Model,
Price as Price,
MacAddress as MacAddress,
ActivationKey as ActivationKey,
Color as Color,
WatchStatus as WatchStatus
FROM Watch;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query);
        }

        public async Task<Watch> GetById(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Watch>> GetWatch(string model, string color)
        {
            const string query = @"
SELECT
WatchId,
Model as Model,
Price as Price,
MacAddress as MacAddress,
ActivationKey as ActivationKey,
Color as Color,
WatchStatus as WatchStatus
FROM Watch
WHERE Model = @Model AND Color = @Color AND OrderId IS NULL;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query, new { Model = model, Color = color });
        }

        public async Task Insert(Watch model)
        { 
            const string query = @"

INSERT INTO Watch (WatchId, Model, Price, MacAddress, ActivationKey, Color, WatchStatus)
VALUES (@Id, @Model, @Price, @MacAddress, @ActivationKey, @Color, @WatchStatus)";


            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);
        }

        public async Task Update(Guid id, bool status)
        {
            const string query = @"
UPDATE Watch 
SET WatchStatus = @Status
WHERE WatchId = @Id";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new {Id = id, Status = status});

        }

        public async Task UpdateWatchDetail(Watch model)
        {
            const string query = @"
UPDATE Watch 
SET Model = @Model,
    Price = @Price,
    Color = @Color
WHERE WatchId = @Id";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id = model.WatchId, Model = model.Model, Price = model.Price, Color = model.Color});

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Watch>> WatchActivate(Guid id, Guid activationKey)
        {
            const string query = @"
SELECT
WatchId,
ActivationKey as ActivationKey
FROM Watch
WHERE 
WatchId = @WatchId AND ActivationKey = @ActivationKey";

            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query, new { WatchId= id, ActivationKey = activationKey });
        }
    }
}
