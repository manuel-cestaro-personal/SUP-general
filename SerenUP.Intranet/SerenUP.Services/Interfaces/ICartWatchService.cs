using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SerenUP.ApplicationCore.Entities;


namespace SerenUP.Services.Interfaces
{
    public interface ICartWatchService
    {
        Task<IEnumerable<Watch>> GetByCartId(Guid id);
        Task DeleteWatch(Guid id);
    }
}

