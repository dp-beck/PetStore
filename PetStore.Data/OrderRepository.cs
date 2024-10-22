using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Models;

namespace PetStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _ProductContext;
        public OrderRepository()
        {
            _ProductContext = new ProductContext();
        }
        public async Task AddOrderAsync(Order order)
        {
            order.OrderDate = DateTime.Now;
            _ProductContext.Orders.Add(order);
            await _ProductContext.SaveChangesAsync();            
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _ProductContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _ProductContext.Orders.Include(p => p.OrderProducts).FirstOrDefaultAsync(p => p.OrderId == orderId)!;
        }
    }
}