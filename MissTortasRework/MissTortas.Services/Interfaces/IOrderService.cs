using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<ConsultancyDTO>> GetUserConsultanciesAsync(long userId);
        public Task<ConsultancyDTO> CreateConsultancyAsync(CreateConsultancyDTO dto);
        public Task<ConsultancyDTO> GetConsultancyAsync(long id);
        public Task EndOrderPreparationAsync(long id);
        public Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync();
        public Task CancelOrderAsync(long id);
        public Task<OrderDTO> SetupOrderAsync(SetupOrderDTO dto);
        public Task<OrderTypeDTO> CreateOrderTypeAsync(CreateOrderTypeDTO dto);
        public Task PlaceOrderAsync(PlaceOrderDTO dto);
        public Task<OrderDTO?> GetOrderAsync(long id);
        internal Task<Order> GetOrderEntityAsync(long id);
        public Task<ConsultancyDTO> UpdateConsultancyAsync(UpdateConsultancyDTO dto);
    }
}
