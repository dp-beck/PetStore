using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Data.Models;

namespace PetStore.WebApi.Logic
{
    public interface IOrderLogic
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}