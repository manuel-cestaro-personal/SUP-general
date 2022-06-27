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
    public class CartAccessoryService : ICartAccessoryService
    {
        private readonly ICartAccessoryRepository _cartAccessoryRepository;

        public CartAccessoryService(ICartAccessoryRepository cartAccessoryRepository)
        {
            _cartAccessoryRepository = cartAccessoryRepository;
        }

        public async Task<IEnumerable<Accessory>> GetByCartId(Guid id)
        {
            return await _cartAccessoryRepository.GetByCartId(id);
        }
    }
}
