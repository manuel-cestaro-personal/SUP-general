using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface ICartWatchRepository
    {
        Task<IEnumerable<CartWatch>> GetAll();
        Task<CartWatch> GetById(Guid id);
        Task Insert(CartWatch model);
        Task Update(CartWatch model);
        Task Delete(Guid id);
    }
}
