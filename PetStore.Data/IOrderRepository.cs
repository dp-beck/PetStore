using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data.Models;

namespace PetStore.Data
{
    public interface IOrderRepository
    {
        public Task AddOrderAsync(Order order);
        
        public Task<Order> GetOrderByIdAsync(int orderId);
        
        public Task<List<Order>> GetAllOrdersAsync();
    }
}