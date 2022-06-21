using SerenUP.ApplicationCore.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IWatchRepository : IRepository<Watch, Guid>
    {
        Task<IEnumerable<Watch>> GetWatch(string Model, string Color);
    }
}
