using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class AccessoryRepository : IAccessoryRepository
    {
        

        public Task<IEnumerable<Accessory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Accessory> GetById(Guid id)
        {

            const string query = @"
SELECT
AccessoryId as Id,
Name as Name,
Price as Price,
Description as Description,
Color as Color,
Quantity as Quantity
FROM Accessory;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryAsync<Accessory>(query);
        }

        public async Task<Accessory> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<Accessory> GetAccessory(string name, string color)
        {
            const string query = @"
SELECT
AccessoryId as Id,
Name as Name,
Price as Price,
Description as Description,
Color as Color,
Quantity as Quantity
FROM Accessory
WHERE Name = @Name AND Color = @Color;";
            using var connection = new SqlConnection(_connectionstring);
            return await connection.QueryFirstOrDefaultAsync<Accessory>(query, new { Name = name, Color = color });

        }

        public async Task Insert(Accessory model)
        {
            const string query = @"
INSERT INTO Accessory (AccessoryId, Name, Price, Description, Color, Quantity)
VALUES (@Id, @Name, @Price, @Description, @Color, @Quantity)";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);
        }

        public async Task Update(Accessory model)
        {
            const string query = @"
UPDATE Accessory 
SET Quantity = @Quantity
WHERE AccessoryId = @Id";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);

        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
