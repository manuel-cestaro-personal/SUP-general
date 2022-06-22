using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IAccessoryRepository : IRepository<Accessory, Guid>
    {
        Task<Accessory> GetAccessory(string name, string color);
    }
}
