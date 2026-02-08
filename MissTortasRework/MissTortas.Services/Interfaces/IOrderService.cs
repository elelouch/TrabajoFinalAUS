using MissTortas.Data.Entity.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IOrderService
    {
        public Task EndOrderPreparation(long id);
        public Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync();
        public Task CancelOrder(long id);
        public Task<OrderDTO> SetupOrder(SetupOrderDTO dto);
        public Task<OrderTypeDTO> CreateOrderType(CreateOrderTypeDTO dto);
        public Task PlaceOrder(PlaceOrderDTO dto);
        public Task<OrderDTO> GetOrderAsync(long id);
    }
}
