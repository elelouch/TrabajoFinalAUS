using MissTortas.Domain.Orders;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.DTO.Products;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class OrderService(
        IUserRepository userRepository,
        IProductService productService,
        IOrderRepository orderRepository,
        IOrderMapper orderMapper
    ) : IOrderService
    {
        public async Task<List<OrderTypeDTO>> AllOrderTypeAsync()
        {
            var orders = await orderRepository.GetAllOrderTypeAsync();
            return orderMapper.OrderTypeToDTO(orders);
        }

        public async Task<OrderTypeDTO> CreateOrderTypeAsync(CreateOrderTypeDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < 3)
            {
                throw new InvalidOperationException("Ordertype name must be greater than zero");
            }
            var orderType = await orderRepository.FindOrderTypeByNameAsync(dto.Name);
            if (orderType is null)
            {
                var newOrderType = new OrderType { Name = dto.Name };
                await orderRepository.InsertOrderTypeAsync(newOrderType);
                await orderRepository.SaveChangesAsync();
                return orderMapper.OrderTypeToDTO(newOrderType);
            }
            return orderMapper.OrderTypeToDTO(orderType);
        }

        public async Task<OrderDTO?> GetOrderAsync(long orderId)
        {
            if (orderId == 0)
                throw new InvalidOperationException("Order id must not be 0");
            var order = await orderRepository.GetDetailedOrderAsync(orderId);
            if (order is null)
            {
                return null;
            }
            return orderMapper.OrderToDTO(order);
        }

        public async Task<OrderDTO> SetupOrderAsync(SetupOrderDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (dto.ClientId == 0)
            {
                throw new InvalidOperationException("ClientId cannot be zero");
            }
            if (dto.AskedProduct.Count <= 0 && dto.ConsultancyId == 0)
            {
                throw new InvalidOperationException("Order must have products or a consultancy");
            }
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId);
            long consultancyId = dto.ConsultancyId;
            if (consultancy is null)
            {
                var createConsultancyDTO = new CreateConsultancyDTO
                {
                    Title = "Automatically generated order.",
                    ClientId = dto.ClientId,
                    AssigneeId = dto.OrderManagerId,
                    ConsultancyStatus = ConsultancyStatus.Approved
                };
                var newConsultancyDTO = await CreateConsultancyAsync(createConsultancyDTO);
                consultancyId = newConsultancyDTO.Id;
            }

            var orderType = await orderRepository.FindOrderTypeAsync(dto.OrderTypeId) ?? throw new OrderTypeNotFoundException("Order type not found");
            var order = new Order
            {
                ConsultancyId = consultancyId,
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
                var productForSale = await productService.GetSaleProductAsync(d.SaleProductId);
                var askIsUnit = Math.Floor(d.QuantityAsked) == d.QuantityAsked;
                if (!(productForSale.AllowDecimalAsk || askIsUnit))
                {
                    // sale product properties required -> {saleproductid, managequantityasinteger}
                    throw new AskQuantityException($"Quantity asked must be integer for the following product: {productForSale.Id}");
                }
                var orderSaleProduct = new OrderSaleProduct { Order = order, SaleProductId = productForSale.Id, QuantityAsked = d.QuantityAsked };
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

                if (saleProduct.SaleQuantity < ask)
                {
                    throw new AskQuantityException("Couldn't execute order, asked quantity is not available for sale.");
                }
                saleProduct.SaleQuantity -= ask;

                if (saleProduct.SaleQuantity <= 0)
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
                saleProduct.SaleQuantity += ask;
            }
        }

        public async Task PlaceOrderAsync(PlaceOrderDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var order = await orderRepository.GetOrderWithAllProductsRelatedAsync(dto.OrderId) ?? throw new OrderNotFoundException("Order not found.");
            var askedProducts = order.ProductsAsked;
            if (order.OrderStatus != OrderStatus.Created)
            {
                throw new InvalidOrderStateException("Order must have a 'Created' status.");
            }
            ReserveProductQuantities(askedProducts);
            order.OrderStatus = OrderStatus.Pending;
            var assignee = order.Consultancy.Assignee;
            var preparation = new OrderPreparation
            {
                Order = order,
                Done = false,
                Assignee = assignee,
                CreationTime = DateTime.Now,
                Detail = "Autogenerated Detail"
            };
            order.Preparations.Add(preparation);
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
        }

        public async Task<OrderPreparationDTO> EndOrderPreparationAsync(long orderPreparationId)
        {
            if (orderPreparationId == 0)
            {
                throw new InvalidOperationException("Order preparation must be valid");
            }
            var orderPreparation = await orderRepository.GetOrderPreparationAsync(orderPreparationId) ?? throw new EntityNotFoundException($"Order preparation with id {orderPreparationId} not found.");
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

            var areOrderPreparationsLeft = order.Preparations.Any(op => op.OrderPreparationId != orderPreparation.OrderPreparationId && !op.Done);

            order.OrderStatus = OrderStatus.InProgress;
            if(!areOrderPreparationsLeft)
            {
                await EndOrderAsync(order.OrderId);
            }

            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderPreparationToDTO(orderPreparation);
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
            await orderRepository.EndAllOrderPreparationsAsync(orderId);
            await orderRepository.SaveChangesAsync();
        }

        public async Task<ConsultancyDTO> CreateConsultancyAsync(CreateConsultancyDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (string.IsNullOrEmpty(dto.Title) || dto.Title.Length < 3)
            {
                throw new InvalidOperationException("The title must have at least 3 characters");
            }
            var client = await userRepository.FindAsync(dto.ClientId) ?? throw new UserNotFoundException($"Client with ID:{dto.ClientId} couldn't be found.");
            var assignee = await userRepository.FindAsync(dto.AssigneeId);
            var consultancy = new Consultancy
            {
                Client = client,
                Assignee = assignee,
                Title = dto.Title,
                Notes = dto.Description,
                Status = dto.ConsultancyStatus ?? ConsultancyStatus.Pending,
            };
            await orderRepository.InsertConsultancyAsync(consultancy);
            await orderRepository.SaveChangesAsync();
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<ConsultancyDTO> UpdateConsultancyAsync(UpdateConsultancyDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var consultancy = await orderRepository.FindConsultancyAsync(dto.ConsultancyId) ?? throw new ConsultancyNotFoundException($"Consultancy {dto.ConsultancyId} not found");
            consultancy.BakeryNotes = dto.BakeryNotes;
            if (!Enum.IsDefined(typeof(ConsultancyStatus), dto.Status))
            {
                throw new ConsultancyNotFoundException($"Cannot assign {dto.Status} as a consultancy status.");
            }
            consultancy.Status = (ConsultancyStatus)dto.Status;
            await orderRepository.SaveChangesAsync();
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<ConsultancyDTO> GetConsultancyAsync(long id)
        {
            if (id == 0)
                throw new InvalidOperationException("Consultancy id must not be 0");
            var consultancy = await orderRepository.FindConsultancyAsync(id) ?? throw new ConsultancyNotFoundException($"Consultancy {id} not found.");
            return orderMapper.ConsultancyToDTO(consultancy);
        }

        public async Task<List<ConsultancyDTO>> GetUserConsultanciesAsync(long userId)
        {
            if (userId == 0)
                throw new InvalidOperationException("User id must not be 0");
            var consultancies = await orderRepository.GetConsultanciesByClientIdAsync(userId);
            return [.. consultancies.Select(c => orderMapper.ConsultancyToDTO(c))];
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllOrdersAsync();
            return orderMapper.OrderToDTO(orders);
        }

        public Task<OrderPreparationDTO?> GetOrderPreparationAsync(long orderPreparationId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderPreparationDTO>> GetUserOrderPreparationsAsync(long userId)
        {
            var ret = await orderRepository.GetUserOrderPreparationsAsync(userId);
            return orderMapper.OrderPreparationToDTO(ret);
        }

        public async Task<OrderPreparationDTO> UpdateOrderPreparationAsync(UpdateOrderPreparationDTO dto)
        {
            var orderPreparation = await orderRepository.GetOrderPreparationAsync(dto.OrderPreparationId) ?? throw new EntityNotFoundException($"Order preparation with id {dto.OrderPreparationId} not found.");
            var newAssignee = await userRepository.FindByIdAsync(dto.AssigneeId) ?? throw new UserNotFoundException("User not found");
            orderPreparation.Assignee = newAssignee;
            orderPreparation.Detail = dto.Detail;
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderPreparationToDTO(orderPreparation);
        }

        public async Task<OrderPreparationDTO> CreateOrderPreparationAsync(CreateOrderPreparationDTO dto)
        {
            var order = await orderRepository.FindAsync(dto.OrderId) ?? throw new OrderNotFoundException($"Order {dto.OrderId} not found.");
            var assignee = await userRepository.FindAsync(dto.OrderId) ?? throw new OrderNotFoundException($"Order {dto.OrderId} not found.");
            if (dto.Detail.Length > 1024)
            {
                throw new InvalidOperationException("The detail can't have more than 1024 characters");
            }
            OrderStatus[] validOrderStatus = [OrderStatus.Pending, OrderStatus.InProgress];
            if (!validOrderStatus.Contains(order.OrderStatus))
            {
                throw new InvalidStateException("The order must be Pending or In Progress to add preparations");
            }
            var newOrderPreparation = new OrderPreparation
            {
                Assignee = assignee,
                Order = order,
                Detail = dto.Detail
            };
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderPreparationToDTO(newOrderPreparation);
        }

        public async Task<OrderDTO> EndOrderAsync(long orderId)
        {
            var order = await orderRepository.GetOrderWithAllProductsRelatedAsync(orderId) ?? throw new OrderNotFoundException($"Order {orderId} not found.");
            OrderStatus[] validOrderStatus = [OrderStatus.Pending, OrderStatus.InProgress, OrderStatus.Created];
            if (!validOrderStatus.Contains(order.OrderStatus))
            {
                throw new InvalidStateException("The order must be just Created, Pending or In Progress to end it");
            }
            order.OrderStatus = OrderStatus.Finished;
            foreach (var orderSaleProduct in order.ProductsAsked)
            {
                var saleProduct = orderSaleProduct.SaleProduct;
                var product = saleProduct.Product;

                // Discount from SaleProduct
                saleProduct.SaleQuantity -= orderSaleProduct.QuantityAsked;

                // Discount from Product
                product.Quantity -= orderSaleProduct.QuantityAsked;
            }
            await orderRepository.EndAllOrderPreparationsAsync(orderId);
            await orderRepository.SaveChangesAsync();
            return orderMapper.OrderToDTO(order);
        }
    }
}
