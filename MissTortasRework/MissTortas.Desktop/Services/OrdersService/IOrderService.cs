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
        public Task CancelOrderAsync(long orderId);
        public Task EndOrderAsync(long orderId);
        public Task EndOrderPreparationAsync(long orderPreparationId);
        public Task<List<Preparation>> GetUserPreparationsAsync();
        public Task<Preparation> UpdateOrderPreparationAsync(long orderPreparationId);
    }
}
