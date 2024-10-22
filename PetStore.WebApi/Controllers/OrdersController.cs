using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data;
using PetStore.Data.Models;
using PetStore.WebApi.Logic;

namespace PetStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderLogic _orderLogic;
        public OrdersController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpGet("{orderId}")]
        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderLogic.GetOrderByIdAsync(orderId);
        }
    }
}