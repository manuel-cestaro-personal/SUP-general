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
    public class CartRepository : ICartRepository
    {
        private readonly string _connectionstring;
        public CartRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SerenUpDB");
        }

        public Task<IEnumerable<Cart>> GetAll()
        {
            throw new NotImplementedException();
            /*const string query = @"
SELECT
Model as Model,
Price as Price,
Color as Color
FROM Watch;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query);*/
        }

        public Task<Cart> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task Update(Cart model)
        {
            throw new NotImplementedException();
        }
        public async Task Insert(Cart model)
        {
            const string query = @"
INSERT INTO Cart (CartId, UserId)
VALUES (@CartId, @UserId); ";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { CartId = model.CartId, UserId = model.UserId });
        }

        public async Task<Cart> GetByUserId(Guid id)
        {
            const string query = @"
                SELECT
                CartId, 
                UserId
                FROM Cart
                WHERE UserId = @Id;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryFirstOrDefaultAsync<Cart>(query, new { Id = id });
        }
    }
}

