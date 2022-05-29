using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderCostCalculator _orderCostCalculator;

        public OrderService(IOrderRepository orderRepository, IMenuRepository menuRepository, IOrderCostCalculator orderCostCalculator)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
            _orderCostCalculator = orderCostCalculator;
        }

        public async Task CreateNewOrder(OrderRequest orderRequest)
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
    }
}
