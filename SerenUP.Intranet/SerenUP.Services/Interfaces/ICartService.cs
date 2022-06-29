using SerenUP.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Interfaces
{
    public interface ICartService
    {
        Task InsertCart(Cart model);
        Task<Guid> FindCartId(Guid userId);

    }
}
