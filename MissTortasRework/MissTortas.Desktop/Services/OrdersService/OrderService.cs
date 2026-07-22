using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.OrdersService
{
    public class OrderService : IOrderService
    {
        private readonly IMissTortasHttpClient httpClient;

        public OrderService(IMissTortasHttpClient httpClient)
        {
            this.httpClient = httpClient;            
        }

        public async Task<Order> GetOrderByIdAsync(long id)
        {
            var order = await httpClient.GetAsync<Order>($"orders/{id}");
            return order!;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await httpClient.GetAsync<List<Order>>("orders");
            return orders!;
        }

        public async Task CancelOrderAsync(long orderId)
        {
            await httpClient.PatchAsync<object>($"orders/{orderId}", new { Status = "cancel" });
        }

        public async Task EndOrderAsync(long orderId)
        {
            await httpClient.PatchAsync<object>($"orders/{orderId}", new { Status = "end" });
        }

        public async Task EndOrderPreparationAsync(long orderPreparationId)
        {
            await httpClient.PatchAsync<object>($"orderpreparations/{orderPreparationId}", new {Status = "end"});
        }

        public async Task<Preparation> UpdateOrderPreparationAsync(long orderPreparationId)
        {
            var preparation = await httpClient.PatchAsync<Preparation>($"orderpreparations/{orderPreparationId}", new { Status = "end" });
            return preparation!;
        }

        public async Task<List<Preparation>> GetUserPreparationsAsync()
        {
            var preparations = await httpClient.GetAsync<List<Preparation>>("orderpreparations");
            return preparations!;
        }
    }
}
