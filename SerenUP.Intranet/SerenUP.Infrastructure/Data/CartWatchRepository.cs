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
        private readonly IConfiguration _configuration;
        public CartWatchRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SerenUpDB");
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartWatch>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CartWatch> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Watch>> GetWatchByCartId(Guid id)
        {
            const string query = @"
                SELECT
				CartWatch.CartWatchId AS WatchId,
                Watch.Color,
				Watch.OrderId,
				Watch.WatchStatus,
				Watch.MacAddress,
				Watch.ActivationKey,
				Watch.Model,
				Watch.Price
                FROM CartWatch INNER JOIN Watch ON CartWatch.WatchId = Watch.WatchId
                WHERE CartWatch.CartId = @Id;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Watch>(query, new { Id = id });
        }

        public Task Insert(CartWatch model)
        {
            throw new NotImplementedException();
        }

        public Task Update(CartWatch model)
        {
            throw new NotImplementedException();
        }
    }
}
