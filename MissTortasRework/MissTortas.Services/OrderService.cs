using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;
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
        ISimpleStorage simpleStorageService,
        IProductService productService,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }

        public async Task<OrderTypeDTO> CreateOrderTypeAsync(CreateOrderTypeDTO dto)
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

        public async Task<OrderDTO> SetupOrderAsync(SetupOrderDTO dto)
        {
            var client = await userManager.FindByIdAsync(dto.ClientId.ToString()) ?? throw new UserNotFoundException("Client not found");
            var orderManager = await userManager.FindByIdAsync(dto.OrderManagerId.ToString()) ?? throw new UserNotFoundException("Order manager not found");
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId);
            var orderType = await orderRepository.FindOrderTypeAsync(dto.OrderTypeId) ?? throw new OrderTypeNotFoundException("Order type not found");
            if(consultancy is null)
            {
                var createConsultancyDTO = new CreateConsultancyDTO
                {
                    ClientId = dto.ClientId,
                    AssigneeId = dto.OrderManagerId,
                };
                var newConsultancyDTO = await CreateConsultancyAsync(createConsultancyDTO);
                consultancy = await orderRepository.FindConsultancyAsync(newConsultancyDTO.Id);
                consultancy!.Status = ConsultancyStatus.Approved;
            }
            var order = new Order
            {
                Consultancy = consultancy,
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

        private static void ReserveProductQuantities(ICollection<OrderSaleProduct> askedProducts)
        {
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

                if (saleProduct.SaleQuantity <= 0)
                {
                    saleProduct.IsAvailable = false;
                }

                if (stockProduct.Quantity < ask)
                {
                    throw new AskQuantityException("Cannot ask more than what's available from the stock.");
                }
                stockProduct.Quantity -= ask;
            }
        }

        private static void FreeProductQuantities(ICollection<OrderSaleProduct> askedProducts)
        {
            foreach (var ap in askedProducts)
            {
                var saleProduct = ap.SaleProduct;
                var stockProduct = saleProduct.StockProduct;
                var ask = ap.QuantityAsked;
                saleProduct.SaleQuantity += ask;
                if (saleProduct.SaleQuantity >= 0)
                {
                    saleProduct.IsAvailable = true;
                }
                stockProduct.Quantity += ask;
            }
        }
        
        public async Task PlaceOrderAsync(PlaceOrderDTO dto)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelated(dto.Id);
            var askedProducts = order.ProductsAsked;
            if(order.OrderStatus != OrderStatus.WaitingForPayment)
            {
                throw new InvalidOrderStateException("Order should be Waiting for Payment.");
            }
            ReserveProductQuantities(askedProducts);
            order.OrderStatus = OrderStatus.Pending;
            var assignee = order.Consultancy.Assignee;
            var preparation = new OrderPreparation 
            { 
                Order = order,
                Done = false, 
                Assignee = assignee,
                CreationTime = DateTime.Now
            };
            order.Preparations.Add(preparation);
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task EndOrderPreparationAsync(long orderPreparationId)
        {
            var orderPreparation = await orderRepository.GetOrderPreparationAsync(orderPreparationId);
            var order = orderPreparation.Order;
            var orderStatus = order.OrderStatus;
            if(orderStatus != OrderStatus.Pending || orderStatus != OrderStatus.InProgress)
            {
                throw new InvalidOrderStateException("Order should be Pending or In Progress.");
            }

            if(orderPreparation.Done)
            {
                throw new InvalidOrderPreparationStateException("Order preparation mustn't be done");
            }

            orderPreparation.FinalizationTime = DateTime.Now;
            orderPreparation.Done = true;

            var areOrderPreparationsLeft = order.Preparations.Any(op => op.Id != orderPreparation.Id && !op.Done);

            order.OrderStatus = areOrderPreparationsLeft ? OrderStatus.InProgress : OrderStatus.Finished;
            
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task CancelOrderAsync(long orderId)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelated(orderId);
            switch (order.OrderStatus)
            {
                case OrderStatus.WaitingForPayment:
                    break;
                case OrderStatus.Pending:
                case OrderStatus.InProgress:
                    FreeProductQuantities(order.ProductsAsked);
                    break;
                default:
                    throw new InvalidOrderStateException("Order state must be Pending, In Progress or Waiting For Payment");
            }
            order.OrderStatus = OrderStatus.Cancelled;
        }

        public async Task<ConsultancyDTO> CreateConsultancyAsync(CreateConsultancyDTO dto)
        {
            var client = await userManager.FindByIdAsync(dto.ClientId.ToString()) ?? throw new UserNotFoundException($"Client with ID:{dto.ClientId} couldn't be found.");
            var assignee = await userManager.FindByIdAsync(dto.AssigneeId.ToString()) ?? throw new UserNotFoundException($"Assigneed with ID:{dto.AssigneeId} couldn't be found."); ;
            var consultancy = new Consultancy
            {
                Client = client,
                Assignee = assignee,
                Title = dto.Title,
                Notes = dto.Description,
                Status = ConsultancyStatus.Pending,
                ConsultancyFiles = []
            };
            await orderRepository.InsertConsultancyAsync(consultancy);
            await orderRepository.SaveChangesAsync();
            await simpleStorageService.SaveConsultancyFileAsync(dto.Files, consultancy);
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<ConsultancyDTO> UpdateConsultancyAsync(UpdateConsultancyDTO dto)
        {
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId) ?? throw new ConsultancyNotFoundException($"Consultancy {dto.ConsultancyId} not found");
            consultancy.BakeryNotes = dto.BakeryNotes;
            if(!Enum.IsDefined(typeof(ConsultancyStatus), dto.Status))
            {
                throw new InvalidStateException($"Cannot assign {dto.Status} as a consultancy status.");
            }
            consultancy.Status = (ConsultancyStatus) dto.Status;
            await orderRepository.SaveChangesAsync();
            return orderMapper.ConsultancyToDTO(consultancy);
        }
    }
}
