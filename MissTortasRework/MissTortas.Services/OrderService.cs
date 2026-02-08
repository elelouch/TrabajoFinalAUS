using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Repositories;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public class OrderService(
        UserManager<ApplicationUser> userManager,
        IProductService productService,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }

        public async Task<OrderTypeDTO> CreateOrderType(CreateOrderTypeDTO dto)
        {
            var orderType = new OrderType { Name = dto.Name };
            await orderRepository.InsertOrderTypeAsync(orderType);
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderTypeToDTO(orderType);
        }

        public async Task<OrderDTO> GetOrderAsync(long orderId)
        {
            try
            {
                var order = await orderRepository.GetOrderWithAllProductsRelated(orderId);
                return orderMapper.OrderToDTO(order);
            }
            catch (InvalidOperationException)
            {
                throw new OrderNotFoundException("Order not found.");
            }
        }

        public async Task<OrderDTO> SetupOrder(SetupOrderDTO dto)
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
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderToDTO(order);
        }

        private async Task PlaceProductAsks(ICollection<AskedProductDTO> dtos, Order order)
        {
            var askedProducts = new List<OrderSaleProduct>(dtos.Count);
            foreach (var d in dtos)
            {
                var productForSale = await productService.GetSaleProductEntityAsync(d.SaleProductId);
                var askIsUnit = Math.Floor(d.QuantityAsked) == d.QuantityAsked;
                if (!(productForSale.AllowDecimalAsk || askIsUnit))
                {
                    throw new AskQuantityException($"Quantity asked must be integer for the following product: {productForSale.Id}");
                }
                if(productForSale.SaleQuantity < d.QuantityAsked)
                {
                    throw new AskQuantityException($"Quantity asked of product is greater than what it's available. Product {productForSale.Id}");
                }
                var orderSaleProduct = new OrderSaleProduct { Order = order, SaleProduct = productForSale, QuantityAsked = d.QuantityAsked };
                askedProducts.Add(orderSaleProduct);
            }
            await orderRepository.BulkInsertOrderSaleProductAsync(askedProducts);
        }

        public async Task PlaceOrder(PlaceOrderDTO dto)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelated(dto.Id);
            var askedProducts = order.ProductsAsked;
            foreach (var ap in askedProducts)
            {
                var saleProduct = ap.SaleProduct;
                var stockProduct = saleProduct.StockProduct;
                var ask = ap.QuantityAsked;

                if (saleProduct.SaleQuantity < ask)
                {
                    throw new AskQuantityException("Couldn't execute order, asked quantity is not available for sale.");
                }
                saleProduct.SaleQuantity -= ask;

                if(saleProduct.SaleQuantity <= 0)
                {
                    saleProduct.IsAvailable = false;
                }

                if(stockProduct.Quantity < ask)
                {
                    throw new AskQuantityException("Cannot ask more than what's available from the stock.");
                }
                stockProduct.Quantity -= ask;
            }
            order.OrderStatus = OrderStatus.Pending;
            var assignee = await userManager.FindByIdAsync(dto.AssigneeId.ToString());

            var preparation = new OrderPreparation { Order = order, Done = false, Detail = "Generic products" };
            if (assignee is not null)
            {
                preparation.Assignee = assignee;
            }

            order.Preparations.Add(preparation);
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task EndOrderPreparation(long id)
        {
            var orderPreparation = await orderRepository.GetOrderPreparationAsync(id);
            orderPreparation.FinalizationTime = DateTime.Now;
            orderPreparation.Done = true;

            var order = orderPreparation.Order;
            var arePreparationOrdersLeft = order.Preparations.Any(op => op.Id != orderPreparation.Id && !op.Done);
            if (!arePreparationOrdersLeft)
            {
                order.OrderStatus = OrderStatus.Finished;
            }
            else
            {
                order.OrderStatus = OrderStatus.InProgress;
            }
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
        }

    }
}
