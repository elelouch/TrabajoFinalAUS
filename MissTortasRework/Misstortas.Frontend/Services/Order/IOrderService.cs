using Misstortas.Frontend.Services.Products;

namespace Misstortas.Frontend.Services.Order
{
    public interface IOrderService
    {
        public Task PostCartAsync(PostCartRequestDTO postCartRequest);
    }
}
