using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SerenUP.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionstring;
        public OrderRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUPWebConnection");
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            const string query = @"
SELECT
OrderAddress as OrderAddress,
Date as Date,
OrderNumber as OrderNumber
FROM Order;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Order>(query);
        }

        public async Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(Order model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Order model)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
