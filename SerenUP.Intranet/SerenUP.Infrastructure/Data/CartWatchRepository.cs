using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class CartWatchRepository : ICartWatchRepository
    {
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
