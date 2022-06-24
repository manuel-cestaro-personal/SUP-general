using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Interfaces;
using SerenUP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Services
{
    public class AccessoryService : IAccessoryService
    {
        private readonly IAccessoryRepository _accessoryRepository;

        public AccessoryService(IAccessoryRepository accessoryRepository)
        {
            _accessoryRepository = accessoryRepository;
        }


        public async Task<IEnumerable<Accessory>> GetAllAccessory()
        {
            return await _accessoryRepository.GetAll();
        }
        public async Task<Accessory> GetAccessory(string name, string color)
        {
            return await _accessoryRepository.GetAccessory(name, color);
        }
        public async Task InsertAccessory(Accessory model)
        {
             await _accessoryRepository.Insert(model);
        }

        public async Task UpdateAccessory(Accessory model)
        {
            await _accessoryRepository.Update(model);
        }
    }
}
