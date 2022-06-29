using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrder();

        Task UpdateStatus(Guid id, string status);

        Task<IEnumerable<Order>> GetByUserId(Guid id);

    }
}
