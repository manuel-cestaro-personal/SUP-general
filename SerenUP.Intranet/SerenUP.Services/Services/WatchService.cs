using SerenUP.ApplicationCore.Entitiess;
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

        public async Task<IEnumerable<Watch>> GetWatch(string Model, string Color)
        {
            return await _watchRepository.GetWatch(Model, Color);
        }

        public async Task InsertWatch(Watch model)
        {
            await _watchRepository.Insert(model);
        }
        public async Task DeleteWatch(Guid Id)
        {
            await _watchRepository.Delete(Id);
        }
    }
}
