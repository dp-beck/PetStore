using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data;
using PetStore.Data.Models;

namespace PetStore.ConsoleApp.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;

        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
            //_orderRepository.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();

            // try
            // {
            //     return _orderRepository.GetOrderById(orderId);
            // }
            // catch (Exception e)
            // {
            //     return null;
            // }        
        }
    }
}