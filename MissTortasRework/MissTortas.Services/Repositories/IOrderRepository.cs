using MissTortas.Domain.Orders;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Services.Repositories
{
    public interface IOrderRepository : IRepositoryCrud<Order>
    {
        public Task<List<Consultancy>> GetConsultanciesByClientIdAsync(long clientId);
        public Task InsertConsultancyAsync(Consultancy consultancy);
        public Task<bool> OrderBelongsToUserAsync(long orderId, long userId);
        public Task<OrderType?> FindOrderTypeAsync(long id);
        public Task<OrderPreparation?> GetOrderPreparationAsync(long id);
        public Task InsertOrderPreparationAsync(OrderPreparation orderPreparation);
        public Task InsertOrderTypeAsync(OrderType ot);
        public Task<List<OrderType>> GetAllOrderTypeAsync();
        public Task<Consultancy?> FindConsultancyAsync(long id);
        public Task InsertOrderSaleProductAsync(OrderSaleProduct osp);
        public Task BulkInsertOrderSaleProductAsync(ICollection<OrderSaleProduct> osps);
        public Task<Order?> GetOrderWithAllProductsRelatedAsync(long id);
        public Task<OrderType?> FindOrderTypeByNameAsync(string name);
        public Task<List<OrderPreparation>> GetUserOrderPreparationsAsync(long userId);
        public Task<List<OrderDADto>> GetAllOrdersAsync();
        public Task<OrderDADto?> GetDetailedOrderAsync(long id);
        public Task<List<Order>> GetOrdersByClientIdAsync(long clientId);
        public Task EndAllOrderPreparationsAsync(long orderId);
        public Task<bool> IsOrderAssigneeAsync(long userId,long orderId);
    }
}
