using MissTortas.Data.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Data.Interfaces
{
    public interface IOrderRepository: IRepositoryCrud<Order>
    {
        public Task<List<OrderType>> FindAllOrderTypeAsync();
    }
}
