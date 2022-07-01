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
    public class CartWatchRepository : ICartWatchRepository
    {
        private readonly string _connectionstring;
        public CartWatchRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUpDB");
        }

        public Task<IEnumerable<CartWatch>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CartWatch> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(CartWatch model)
        {
            throw new NotImplementedException();
        }

        public Task Update(CartWatch model)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Guid id)
        {
            const string query = @"
DELETE FROM CartWatch
WHERE CartWatchId = @Id";
            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
