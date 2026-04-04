using MissTortas.Domain.Orders;
using MissTortas.Domain.Repositories;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services
{
    public class OrderService(
        IUserRepository userRepository,
        IProductService productService,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper
    ) : IOrderService
    {
        public async Task<IEnumerable<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = orderRepository.GetAllOrderType();
            var orderList = await orders.ToListAsync();
            return orderMapper.OrderTypeToDTO(orderList);
        }

        public async Task<OrderTypeDTO> CreateOrderTypeAsync(CreateOrderTypeDTO dto)
        {
            var orderType = new OrderType { Name = dto.Name };
            await orderRepository.InsertOrderTypeAsync(orderType);
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderTypeToDTO(orderType);
        }

        public async Task<OrderDTO?> GetOrderAsync(long orderId)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelatedAsync(orderId);
            if (order is null)
            {
                return null;
            }
            return orderMapper.OrderToDTO(order);
        }

        public async Task<OrderDTO> SetupOrderAsync(SetupOrderDTO dto)
        {
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId);
            if (consultancy is null)
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

            var orderType = await orderRepository.FindOrderTypeAsync(dto.OrderTypeId) ?? throw new OrderTypeNotFoundException("Order type not found");
            var order = new Order
            {
                Consultancy = consultancy,
                OrderType = orderType,
                OrderStatus = OrderStatus.Created
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
                var ask = ap.QuantityAsked;

                if (saleProduct.Quantity < ask)
                {
                    throw new AskQuantityException("Couldn't execute order, asked quantity is not available for sale.");
                }
                saleProduct.Quantity -= ask;

                if (saleProduct.Quantity <= 0)
                {
                    saleProduct.IsAvailable = false;
                }
            }
        }

        private static void FreeProductQuantities(ICollection<OrderSaleProduct> askedProducts)
        {
            foreach (var ap in askedProducts)
            {
                var saleProduct = ap.SaleProduct;
                var ask = ap.QuantityAsked;
                saleProduct.Quantity += ask;
            }
        }

        public async Task PlaceOrderAsync(PlaceOrderDTO dto)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelatedAsync(dto.OrderId) ?? throw new OrderNotFoundException("Order not found.");
            var askedProducts = order.ProductsAsked;
            if (order.OrderStatus != OrderStatus.Created)
            {
                throw new InvalidOrderStateException("Order should be just created.");
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
            if (orderStatus != OrderStatus.Pending || orderStatus != OrderStatus.InProgress)
            {
                throw new InvalidOrderStateException("Order should be Pending or In Progress.");
            }

            if (orderPreparation.Done)
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
            var order = await orderRepository.GetOrderWithAllProductsRelatedAsync(orderId) ?? throw new OrderNotFoundException("Order not found."); switch (order.OrderStatus)
            {
                case OrderStatus.Created:
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
            var client = await userRepository.FindAsync(dto.ClientId) ?? throw new UserNotFoundException($"Client with ID:{dto.ClientId} couldn't be found.");
            var assignee = await userRepository.FindAsync(dto.AssigneeId) ?? throw new UserNotFoundException($"Assigneed with ID:{dto.AssigneeId} couldn't be found.");
            var consultancy = new Consultancy
            {
                Client = client,
                Assignee = assignee,
                Title = dto.Title,
                Notes = dto.Description,
                Status = ConsultancyStatus.Pending,
            };
            await orderRepository.InsertConsultancyAsync(consultancy);
            await orderRepository.SaveChangesAsync();
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<ConsultancyDTO> UpdateConsultancyAsync(UpdateConsultancyDTO dto)
        {
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId) ?? throw new ConsultancyNotFoundException($"Consultancy {dto.ConsultancyId} not found");
            consultancy.BakeryNotes = dto.BakeryNotes;
            if (!Enum.IsDefined(typeof(ConsultancyStatus), dto.Status))
            {
                throw new InvalidStateException($"Cannot assign {dto.Status} as a consultancy status.");
            }
            consultancy.Status = (ConsultancyStatus)dto.Status;
            await orderRepository.SaveChangesAsync();
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<Order> GetOrderEntityAsync(long id)
        {
            return await orderRepository.FindAsync(id) ?? throw new OrderNotFoundException($"Order: {id} not found");
        }

        public async Task<ConsultancyDTO> GetConsultancyAsync(long id)
        {
            var consultancy = await orderRepository.FindConsultancyAsync(id) ?? throw new ConsultancyNotFoundException($"Consultancy {id} not found.");
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<IEnumerable<ConsultancyDTO>> GetUserConsultanciesAsync(long userId)
        {
            var consultancies = orderRepository.GetConsultanciesByClientId(userId);
            return await consultancies.Select(c => orderMapper.ConsultancyToDTO(c)).ToListAsync();
        }
    }
}
