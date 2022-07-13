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
    public class WatchService : IWatchService
    {
        private readonly IWatchRepository _watchRepository;

        public WatchService(IWatchRepository watchRepository)
        {
            _watchRepository = watchRepository;
        }

        public async Task<IEnumerable<Watch>> GetAllWatch()
        {
            return await _watchRepository.GetAll();
        }

        public async Task<IEnumerable<Watch>> GetWatch(string model, string color)
        {
            return await _watchRepository.GetWatch(model, color);
        }

        public async Task InsertWatch(Watch model)
        {
            await _watchRepository.Insert(model);
        }

        public async Task UpdateWatch(Guid id, bool status)
        {
            await _watchRepository.Update(id, status);
        }

        public async Task UpdateWatchDetail(Watch model)
        {
            await _watchRepository.UpdateWatchDetail(model);
        }

        public async Task<IEnumerable<Watch>> WatchActivate(Guid id, Guid activationKey)
        {
            return await _watchRepository.WatchActivate(id, activationKey);
        }
    }
}
