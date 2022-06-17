using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace SerenUP.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionstring;
        public OrderRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUPIntranetContextConnection");
        }

        public IEnumerable<Order> GetAll()
        {
            const string query = @"
SELECT
OrderAddress as OrderAddress
Date as Date
OrderNumber as OrderNumber
FROM Order;";
            using var connection = new MySqlConnection(_connectionstring);
            return connection.Query<Order>(query);
        }

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order model)
        {
            throw new NotImplementedException();
        }

        public void Update(Order model)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
        }
    }
}
