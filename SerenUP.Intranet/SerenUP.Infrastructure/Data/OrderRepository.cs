using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace SerenUP.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionstring;
        public OrderRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUpDB");
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            const string query = @"
SELECT 
       OrderId
      ,UserId
      ,Status
      ,OrderAddress
      ,Date
      ,OrderNumber
FROM [Order];";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Order>(query);
        }

        public async Task<IEnumerable<Order>> GetByUserId(Guid id)
        {
            const string query = @"
SELECT
        OrderId,
        UserId,
        Status,
        OrderAddress,
        Date,
        OrderNumber
FROM [Order]
WHERE UserId = @UserId;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Order>(query, new { UserId = id });
        }

        public async Task Insert(Order model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStatus(Guid id, string status)
        {
            const string query = @"
UPDATE [Order] 
SET Status = @Status
WHERE OrderId = @Id;";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new {Id = id, Status = status});
        }
        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
