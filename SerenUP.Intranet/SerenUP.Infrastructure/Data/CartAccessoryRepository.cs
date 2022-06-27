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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartAccessory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Accessory>> GetByCartId(Guid id)
        {
            const string query = @"
                SELECT
				Accessory.AccessoryId,
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

        public Task Update(CartAccessory model)
        {
            throw new NotImplementedException();
        }
    }
}
