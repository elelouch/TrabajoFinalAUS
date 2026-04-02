using MissTortas.Domain.Orders;

namespace MissTortas.Domain.Repositories
{
    public interface IOrderRepository : IRepositoryCrud<Order>
    {
        public IAsyncEnumerable<Consultancy> GetConsultanciesByClientId(long clientId);
        public Task InsertConsultancyAsync(Consultancy consultancy);
        public Task<OrderType?> FindOrderTypeAsync(long id);
        public Task<OrderPreparation> GetOrderPreparationAsync(long id);
        public Task InsertOrderTypeAsync(OrderType ot);
        public IAsyncEnumerable<OrderType> GetAllOrderType();
        public Task<Consultancy?> FindConsultancyAsync(long id);
        public Task InsertOrderSaleProductAsync(OrderSaleProduct osp);
        public Task BulkInsertOrderSaleProductAsync(ICollection<OrderSaleProduct> osps);
        public Task<Order?> GetOrderWithAllProductsRelatedAsync(long id);
        public Task<bool> BelongsToUserAsync(long orderId, long userId);
    }
}
