using food_order_service.Models;
using food_order_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_order_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewOrder(OrderRequest orderRequest)
        {
            try
            {
                int id = await _orderService.CreateNewOrder(orderRequest);

                return Created("", new { OrderId = id });
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.ToString());
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }
    }
}
