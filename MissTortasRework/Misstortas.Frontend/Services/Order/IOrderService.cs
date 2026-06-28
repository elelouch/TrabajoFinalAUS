namespace Misstortas.Frontend.Services.Order
{
    public interface IOrderService
    {
        public Task<long> PostCartAsync();
    }
}
