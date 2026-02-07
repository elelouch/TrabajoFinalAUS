using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync();
        public Task<OrderDTO> PlaceOrder(PlaceOrderDTO dto);
        public Task<OrderTypeDTO> CreateOrderType(CreateOrderTypeDTO dto);
    }
}
