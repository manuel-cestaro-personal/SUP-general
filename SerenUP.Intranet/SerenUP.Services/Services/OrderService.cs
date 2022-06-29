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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _orderRepository.GetAll();
        }

        public async Task UpdateStatus(Guid id, string status)
        {
            await _orderRepository.UpdateStatus(id, status);
        }

        public async Task<IEnumerable<Order>> GetByUserId(Guid id)
        {
           return await _orderRepository.GetByUserId(id);
        }
    }
}
