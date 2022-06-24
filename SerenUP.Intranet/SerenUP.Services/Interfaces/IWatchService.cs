using SerenUP.ApplicationCore.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Interfaces
{
    public interface IWatchService
    {
        Task<IEnumerable<Watch>> GetAllWatch();
        Task InsertWatch(Watch model);
        Task DeleteWatch(Guid id);
        Task<IEnumerable<Watch>> GetWatch(string model, string color);

    }
}