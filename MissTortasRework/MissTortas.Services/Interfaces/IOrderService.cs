using MissTortas.Data.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Engine.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderType>> AllOrderTypeAsync();
    }
}
