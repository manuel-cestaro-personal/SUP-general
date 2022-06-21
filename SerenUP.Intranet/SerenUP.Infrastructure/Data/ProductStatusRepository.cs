using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class ProductStatusRepository : IProductStatusRepository
    {
        public Task<IEnumerable<ProductStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductStatus> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(ProductStatus model)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductStatus model)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
