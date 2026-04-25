using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Orders;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class OrderRepository(MissTortasContext context) : RepositoryCrud<Order>(context), IOrderRepository
    {
        private readonly DbSet<Consultancy> consultanciesSet = context.Consultancies;
        private readonly DbSet<OrderType> orderTypeSet = context.OrderTypes;
        private readonly DbSet<OrderSaleProduct> askedProductsSet = context.AskedProducts;
        private readonly DbSet<Order> orderSet = context.Orders;
        private readonly DbSet<OrderPreparation> orderPreparationsSet = context.OrderPreparations;

        public async Task<Order?> GetOrderWithAllProductsRelatedAsync(long id)
        {
            var order = await orderSet.Include(order => order.ProductsAsked)
                .ThenInclude(asked => asked.SaleProduct)
                .Include(order => order.Consultancy)
                .ThenInclude(c => c.Assignee)
                .Include(order => order.Consultancy)
                .ThenInclude(c => c.Client)
                .Include(order => order.Preparations)
                .Where(order => order.Id == id)
                .SingleOrDefaultAsync();
            return order;
        }

        public async Task InsertConsultancyAsync(Consultancy consultancy)
        {
            await consultanciesSet.AddAsync(consultancy);
        }

        public async Task<Consultancy?> FindConsultancyAsync(long id)
        {
            return await consultanciesSet.FindAsync(id);
        }

        public async Task<OrderType?> FindOrderTypeAsync(long id)
        {
            return await orderTypeSet.FindAsync(id);
        }

        public IAsyncEnumerable<OrderType> GetAllOrderType()
        {
            return orderTypeSet.AsAsyncEnumerable();
        }

        public async Task InsertOrderSaleProductAsync(OrderSaleProduct osp)
        {
            await askedProductsSet.AddAsync(osp);
        }

        public async Task BulkInsertOrderSaleProductAsync(ICollection<OrderSaleProduct> osps)
        {
            await askedProductsSet.AddRangeAsync(osps);
        }

        public async Task InsertOrderTypeAsync(OrderType ot)
        {
            await orderTypeSet.AddAsync(ot);
        }

        public async Task<OrderPreparation> GetOrderPreparationAsync(long id)
        {
            var op = await orderPreparationsSet
                .Include(op => op.Order)
                .ThenInclude(order => order.Preparations)
                .SingleAsync();
            return op;
        }

        public IAsyncEnumerable<Consultancy> GetConsultanciesByClientId(long clientId)
        {
            return consultanciesSet
                .Include(c => c.Client)
                .Where(c => c.Client.Id == clientId)
                .AsAsyncEnumerable();
        }

        public Task<bool> BelongsToUserAsync(long orderId, long userId)
        {
            return orderSet.AnyAsync(o => o.Id == orderId && o.Consultancy.Client.Id == userId);
        }
    }
}
