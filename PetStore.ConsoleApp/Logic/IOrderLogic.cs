using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data.Models;

namespace PetStore.ConsoleApp.Logic
{
    public interface IOrderLogic
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrderById(int orderId);
    }
}