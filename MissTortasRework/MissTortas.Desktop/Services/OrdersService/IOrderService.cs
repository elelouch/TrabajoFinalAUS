using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.OrdersService
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrdersAsync();
        public Task<Order> GetOrderByIdAsync(long id);
    }
}
