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
    }
}
