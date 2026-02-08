using MissTortas.Data.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Data.Interfaces
{
    public interface IOrderRepository: IRepositoryCrud<Order>
    {
        public Task<OrderType?> FindOrderTypeAsync(long id);
        public Task<OrderPreparation> GetOrderPreparationAsync(long id);
        public Task InsertOrderTypeAsync(OrderType ot);
        public Task<IEnumerable<OrderType>> GetAllOrderTypeAsync();
        public Task<Consultancy?> FindConsultancyAsync(long id);
        public Task InsertOrderSaleProductAsync(OrderSaleProduct osp);
        public Task BulkInsertOrderSaleProductAsync(ICollection<OrderSaleProduct> osps);
        public Task<Order> GetOrderWithAllProductsRelated(long id);
    }
}
