using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Interfaces
{
    public interface IAccessoryService
    {
        Task<IEnumerable<Accessory>> GetAllAccessory();
        Task InsertAccessory(Accessory name);
        Task DeleteAccessory(Guid id);
        Task<Accessory> GetAccessory(string name, string color);
    }
}
