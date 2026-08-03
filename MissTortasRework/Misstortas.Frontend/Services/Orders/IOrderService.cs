using Misstortas.Frontend.Models;

namespace Misstortas.Frontend.Services.Orders
{
    public interface IOrderService
    {
        public Task<long> PostCartAsync();
        public Task<List<Order>> GetOrdersAsync();
        public Task<Order> GetOrderByIdAsync(long orderId);
        public Task CancelOrderByIdAsync(long id);
    }
}
