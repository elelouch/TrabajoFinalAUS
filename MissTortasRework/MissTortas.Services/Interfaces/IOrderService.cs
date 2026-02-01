using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync();
        public Task<OrderDTO> PlaceOrder(PlaceOrderDTO dto);
    }
}
