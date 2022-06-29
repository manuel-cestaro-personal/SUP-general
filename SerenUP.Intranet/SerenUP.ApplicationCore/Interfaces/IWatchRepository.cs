using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IWatchRepository
    {
        Task<IEnumerable<Watch>> GetWatch(string Model, string Color);
        Task<IEnumerable<Watch>> GetAll();
        Task<Watch> GetById(Guid id);
        Task Insert(Watch model);
        Task Update(Watch model);
        Task Delete(Guid id);

        Task<IEnumerable<Watch>> WatchActivate(Guid id, Guid activationKey);
    }
}
