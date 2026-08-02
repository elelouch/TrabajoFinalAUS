using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Orders;
using MissTortas.Domain.Products;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;
using MissTortas.Services.Repositories.DTO;

namespace MissTortas.Infrastructure.Repositories
{
    public class OrderRepository(MissTortasContext context) : RepositoryCrud<Order>(context), IOrderRepository
    {
        private readonly DbSet<Consultancy> consultanciesSet = context.Consultancies;
        private readonly DbSet<OrderType> orderTypeSet = context.OrderTypes;
        private readonly DbSet<OrderSaleProduct> askedProductsSet = context.AskedProducts;
        private readonly DbSet<Order> orderSet = context.Orders;
        private readonly DbSet<OrderPreparation> orderPreparationsSet = context.OrderPreparations;
        private readonly DbSet<Product> productsSet = context.Products;

        public async Task<Order?> GetOrderWithAllProductsRelatedAsync(long id)
        {
            var order = await orderSet
                .AsSplitQuery()
                .Include(order => order.ProductsAsked)
                    .ThenInclude(asked => asked.SaleProduct)
                        .ThenInclude(sp => sp.Product)
                .Include(order => order.Consultancy)
                    .ThenInclude(c => c.Assignee)
                .Include(order => order.Consultancy)
                    .ThenInclude(c => c.Client)
                .Include(order => order.Preparations)
                .Where(order => order.OrderId == id)
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

        public async Task<List<OrderType>> GetAllOrderTypeAsync()
        {
            return await orderTypeSet.ToListAsync();
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

        public async Task<OrderPreparation?> GetOrderPreparationAsync(long id)
        {
            var op = await orderPreparationsSet
                .Include(op => op.Order)
                .ThenInclude(order => order.Preparations)
                .Where(op => op.OrderPreparationId == id)
                .SingleOrDefaultAsync();
            return op;
        }

        public Task<List<Consultancy>> GetConsultanciesByClientIdAsync(long clientId)
        {
            return consultanciesSet
                .Include(c => c.Client)
                .Where(c => c.Client.UserId == clientId)
                .ToListAsync();
        }

        public Task<bool> OrderBelongsToUserAsync(long orderId, long userId)
        {
            return orderSet.AnyAsync(o => o.OrderId == orderId && o.Consultancy.ClientId == userId);
        }

        public Task<OrderType?> FindOrderTypeByNameAsync(string name)
        {
            return orderTypeSet.Where(ot => ot.Name == name).SingleOrDefaultAsync();
        }

        public Task<List<OrderPreparation>> GetUserOrderPreparationsAsync(long userId)
        {
            return orderPreparationsSet.Where(op => op.AssigneeId == userId).ToListAsync();
        }

        public Task<List<OrderDADto>> GetAllOrdersAsync()
        {
            return orderSet.ToOrderDADto().ToListAsync();
        }

        public async Task<OrderDADto?> GetDetailedOrderAsync(long id)
        {
            return orderSet.Where(o => o.OrderId == id).ToDetailedOrderDADto().SingleOrDefault();
        }

        public async Task EndAllOrderPreparationsAsync(long orderId)
        {
            await orderPreparationsSet
                .Where(op => op.OrderId == orderId)
                .ExecuteUpdateAsync(setter => setter.SetProperty(op => op.Done, true));
        }

        public async Task<bool> IsOrderAssigneeAsync(long assigneeId, long orderId)
        {
            return await orderSet.AnyAsync(o => o.OrderId == orderId && o.Preparations.Any(p => p.AssigneeId == assigneeId));
        }

        public async Task InsertOrderPreparationAsync(OrderPreparation orderPreparation)
        {
            await orderPreparationsSet.AddAsync(orderPreparation);
        }

        public Task<List<Order>> GetOrdersByClientIdAsync(long clientId)
        {
            return orderSet.Where(o => o.Consultancy.ClientId == clientId).ToListAsync();
        }
    }
}
