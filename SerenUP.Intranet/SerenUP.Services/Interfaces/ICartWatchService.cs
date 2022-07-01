using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Interfaces
{
    public interface ICartWatchService
    {
        Task DeleteWatch(Guid id);
    }
}
