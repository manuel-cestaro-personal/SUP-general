using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetByUserId(Guid id);
        Task Insert(Order model);
        Task UpdateStatus(Guid id, string status);
        Task Update(Order model);
        Task Delete(Guid id);
    }
}
