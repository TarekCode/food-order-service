using food_order_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_order_service.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        //public async Task AddNewOrder()
        //{

        //}
    }
}
