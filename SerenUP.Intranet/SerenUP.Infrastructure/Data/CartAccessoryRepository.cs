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
    public class CartAccessoryRepository: ICartAccessoryRepository
    {
        private readonly string _connectionstring;
        private readonly IConfiguration _configuration;
        public CartAccessoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SerenUpDB");
        }

        

        public Task<IEnumerable<CartAccessory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Accessory>> GetByCartId(Guid id)
        {
            const string query = @"
                SELECT
				CartAccessory.CartAccessoryId AS AccessoryId,
                Accessory.Color,
				Accessory.Description,
				Accessory.Name,
				Accessory.Price,
				CartAccessory.Quantity
                FROM CartAccessory INNER JOIN Accessory ON CartAccessory.AccessoryId = Accessory.AccessoryId
                WHERE CartAccessory.CartId = @Id;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Accessory>(query, new { Id = id });
        }

        //get the C
        public Task<CartAccessory> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(CartAccessory model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Guid id, int quantity)
        {
            const string query = @"
UPDATE CartAccessory
SET Quantity = @Quantity
WHERE CartAccessoryId = @Id
";
            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id = id, Quantity = quantity});
        }
        public async Task Delete(Guid id)
        {
            const string query = @"
DELETE FROM CartAccessory
WHERE CartAccessoryId = @Id";
            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
