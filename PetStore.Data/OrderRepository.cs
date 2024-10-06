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
        public void AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _ProductContext.Orders.Add(order);
            _ProductContext.SaveChanges();            
        }

        public List<Order> GetAllOrders()
        {
            return _ProductContext.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _ProductContext.Orders.Include(p => p.OrderProducts).FirstOrDefault(p => p.OrderId == orderId)!;
        }
    }
}