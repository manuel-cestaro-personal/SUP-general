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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Guid> FindCartId(Guid userId)
        {
            Cart cart = await _cartRepository.GetByUserId(userId);
            return cart.CartId;
        }

        public async Task InsertCart(Cart model)
        {
            await _cartRepository.Insert(model);
        }
    }
}
