using food_order_service.Data_layer.DataModels;
using food_order_service.Data_layer.Repositories;
using food_order_service.Models;

namespace food_order_service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuRepository _menuRepository;

        public OrderService(IOrderRepository orderRepository, IMenuRepository menuRepository)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
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

            await MapOrderItems(orderRequest.OrderItems, order.OrderItems);

            await _orderRepository.SaveNewOrder(order);
        }

        private async Task MapOrderItems(ICollection<OrderItemRequest> orderItemRequests, ICollection<OrderItem> orderItems)
        {
            foreach (OrderItemRequest orderItem in orderItemRequests)
            {
                MenuItem menuItem = await GetMenuItem(orderItem.MenuItemId);

                orderItems.Add(new OrderItem()
                {
                    MenuItemId = menuItem.Id                    
                });
            }
        }

        private async Task<MenuItem> GetMenuItem(int id)
        {
            var item = await _menuRepository.GetById(id);

            if (item == null)
            {
                throw new ArgumentException($"Could not find menu item with id: {id}");
            }

            return item;
        }
    }
}
