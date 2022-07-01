using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface ICartAccessoryRepository
    {
        Task<IEnumerable<Accessory>> GetByCartId(Guid id);
        Task<IEnumerable<CartAccessory>> GetAll();
        Task<CartAccessory> GetById(Guid id);
        Task Insert(CartAccessory model);
        Task Update(Guid id, int quantity);
        Task Delete(Guid id);
    }
}
