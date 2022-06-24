﻿using SerenUP.ApplicationCore.Entities;
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
            throw new NotImplementedException();
        }

        public Task Insert(Accessory model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Accessory model)
        {
            const string query = @"
UPDATE Accessory
SET Quantity = @Quantity
WHERE AccessoryId = @Id;";

            using var connection = new SqlConnection(_connectionstring);
            await connection.ExecuteAsync(query, model);
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
