using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data.Models;

namespace PetStore.Data
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);
        
        public Order GetOrderById(int orderId);
        
        public List<Order> GetAllOrders();
    }
}