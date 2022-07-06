using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IAccessoryRepository
    {
        Task<Accessory> GetAccessory(string name, string color);
        Task<IEnumerable<Accessory>> GetAll();
        Task<Accessory> GetById(Guid id);
        Task Insert(Accessory model);
        Task Update(Guid id, int quantity);
        Task Delete(Guid id);
    }
}
