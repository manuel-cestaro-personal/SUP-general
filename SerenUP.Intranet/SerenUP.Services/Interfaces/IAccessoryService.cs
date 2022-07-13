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
        Task<Accessory> GetAccessory(string name, string color);
        Task InsertAccessory(Accessory name);
        Task UpdateAccessory(Accessory model);
        
    }
}
