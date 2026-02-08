using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Context;

namespace MissTortas.Data.Repositories
{
    public class OrderRepository(MissTortasContext context) : RepositoryCrud<Order>(context), IOrderRepository
    {
        private readonly DbSet<Consultancy> consultanciesSet = context.Consultancies;
        private readonly DbSet<OrderType> orderTypeSet = context.OrderTypes;
        private readonly DbSet<OrderSaleProduct> askedProductsSet = context.AskedProducts;
        private readonly DbSet<Order> orderSet = context.OrderItems;
        private readonly DbSet<OrderPreparation> orderPreparationsSet = context.OrderPreparations;


        public async Task<Order> GetOrderWithAllProductsRelated(long id)
        {
            var order = await orderSet.Include(order => order.ProductsAsked)
                .ThenInclude(asked => asked.SaleProduct)
                .ThenInclude(sp => sp.StockProduct)
                .Include(order => order.Preparations)
                .Include(order => order.OrderManager)
                .Include(order => order.Client)
                .Where(order => order.Id == id)
                .SingleAsync();
            return order;
        }

        public async Task<Consultancy?> FindConsultancyAsync(long id)
        {
            return (await consultanciesSet.FindAsync(id));
        }

        public async Task<OrderType?> FindOrderTypeAsync(long id)
        {
            return (await orderTypeSet.FindAsync(id));
        }

        public async Task<IEnumerable<OrderType>> GetAllOrderTypeAsync()
        {
            return (await orderTypeSet.ToListAsync());
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
    }
}
