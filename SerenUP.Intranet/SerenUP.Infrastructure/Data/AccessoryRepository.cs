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
            throw new NotImplementedException();
        }

        public Task Insert(Accessory model)
        {
            throw new NotImplementedException();
        }

        public Task Update(Accessory model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
