using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Infrastructure.Data
{
    public class OrderStatusRepository : IOrderStatusRepository
    {


        public Task<IEnumerable<OrderStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderStatus> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(OrderStatus model)
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderStatus model)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
