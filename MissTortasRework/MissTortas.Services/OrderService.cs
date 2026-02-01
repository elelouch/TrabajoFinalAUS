using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Repositories;
using MissTortas.Services.DTO.Order;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public class OrderService(
        UserManager<ApplicationUser> userManager,
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }

        public async Task<OrderDTO?> GetOrder(long orderId)
        {
            var order = await orderRepository.FindAsync(orderId);
            if (order is null)
            {
                return null;
            }
            return orderMapper.OrderToDTO(order);
        }

        public async Task<OrderDTO> PlaceOrder(PlaceOrderDTO dto)
        {
            var client = await userManager.FindByIdAsync(dto.ClientId.ToString()) ?? throw new UserNotFoundException("Client not found");
            var orderManager = await userManager.FindByIdAsync(dto.OrderManagerId.ToString()) ?? throw new UserNotFoundException("Order manager not found");
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId);
            var orderType = await orderRepository.FindOrderTypeAsync(dto.OrderTypeId) ?? throw new OrderTypeNotFoundException("Order type not found");
            var order = new Order
            {
                Consultancy = consultancy,
                Client = client,
                OrderManager = orderManager,
                OrderType = orderType,
                OrderStatus = OrderStatus.WaitingForPayment
            };
            await orderRepository.InsertAsync(order);
            await PlaceProductAsks(dto.AskedProduct, order);
            return orderMapper.OrderToDTO(order);
        }

        private async Task PlaceProductAsks(ICollection<AskedProductDTO> dtos, Order order)
        {
            foreach (var dto in dtos)
            {
                var productForSale = await productRepository.FindSaleProductAsync(dto.SaleProductId) ?? throw new SaleProductNotFoundException("Product for sale not found");
                var askedProduct = new OrderSaleProduct { Order = order, SaleProduct = productForSale, QuantityAsked = dto.Quantity };
                await orderRepository.InsertOrderSaleProductAsync(askedProduct);
            }
            await orderRepository.SaveChangesAsync();
        }
    }
}
