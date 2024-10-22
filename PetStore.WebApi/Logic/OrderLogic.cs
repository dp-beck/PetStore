using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data;
using PetStore.Data.Models;

namespace PetStore.WebApi.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;

        public OrderLogic(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                return await _orderRepository.GetAllOrdersAsync();
            }
            catch (Exception e)
            {
                
                return null;
            }
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {

            try
            {
                return await _orderRepository.GetOrderByIdAsync(orderId);
            }
            catch (Exception e)
            {
                 return null;
            }        
        }
    }
}