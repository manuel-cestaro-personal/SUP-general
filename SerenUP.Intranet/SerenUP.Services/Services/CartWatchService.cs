using SerenUP.ApplicationCore.Interfaces;
using SerenUP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerenUP.Services.Services
{
    public class CartWatchService : ICartWatchService
    {
        private readonly ICartWatchRepository _cartWatchRepository;

        public CartWatchService(ICartWatchRepository cartWatchRepository)
        {
            _cartWatchRepository = cartWatchRepository;
        }

        public async Task DeleteWatch(Guid id)
        {
            await _cartWatchRepository.Delete(id);
        }
    }
}
