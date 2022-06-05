using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderResponseBuilder _openOrderBuilder;
        private readonly IOrderCostCalculator _orderCostCalculator;

        public OrderService(IOrderRepository orderRepository, IOrderResponseBuilder openOrderBuilder, IOrderCostCalculator orderCostCalculator)
        {
            _orderRepository = orderRepository;
            _openOrderBuilder = openOrderBuilder;
            _orderCostCalculator = orderCostCalculator;
        }

        public async Task<int> CreateNewOrder(OrderRequest orderRequest)
        {
            if (orderRequest.OrderItems.Count == 0)
            {
                throw new Exception("Order cannot have 0 items");
            }

            var order = new Order()
            {
                CustomerName = orderRequest.Name,
                PhoneNumber = orderRequest.Phone,
                OrderStatus = OrderStatusOptions.New,
                OrderItems = new List<OrderItem>()
            };

            MapOrderItems(orderRequest.OrderItems, order.OrderItems);

            await _orderCostCalculator.CalculateCost(order);
            await _orderRepository.SaveNewOrder(order);

            return order.Id;
        }

        public async Task<IEnumerable<OrderResponse>> GetOpenOrders()
        {
            List<OrderResponse> orderResponses = new List<OrderResponse>();

            var orders = await _orderRepository.GetOrders(OrderStatusOptions.New);

            foreach (var order in orders)
            {
                orderResponses.Add(await _openOrderBuilder.BuildOrderResponse(order));
            }

            return orderResponses;
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            ValidateStatus(status);

            if (!await _orderRepository.SetOrderStatus(orderId, status))
            {
                throw new ArgumentException("could not find order with id " + orderId);
            }
        }

        private void MapOrderItems(ICollection<OrderItemRequest> orderItemRequests, ICollection<OrderItem> orderItems)
        {
            foreach (OrderItemRequest orderItem in orderItemRequests)
            {
                orderItems.Add(new OrderItem()
                {
                    MenuItemId = orderItem.MenuItemId,
                    ItemModifications = orderItem.Modifications?
                    .Select(x => new ItemModification()
                    {
                        ItemOptionId = x.ItemOptionId,
                        ChangeType = x.ChangeType
                    }).ToList()
                });
            }
        }

        private void ValidateStatus(string status)
        {
            if (status != OrderStatusOptions.New
                && status != OrderStatusOptions.Cancelled
                && status != OrderStatusOptions.Completed)
            {
                throw new BadHttpRequestException("invalid order status");
            }
        }
    }
}
