using SerenUP.ApplicationCore.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.ApplicationCore.Interfaces
{
    internal interface IWatchRepository : IOrderRepository<Watch, Guid>
    {
    }
}
