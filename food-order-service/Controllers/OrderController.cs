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
        private readonly ISystemConfiguration _systemConfiguration;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, ISystemConfiguration systemConfiguration)
        {
            _logger = logger;
            _orderService = orderService;
            _systemConfiguration = systemConfiguration;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> AddNewOrder(OrderRequest orderRequest)
        {
            try
            {
                if (!await _systemConfiguration.AcceptingOrders())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Not accepting orders at the moment.");
                }

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
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOpenOrders()
        {
            try
            {
                var orders = await _orderService.GetOpenOrders();

                return Ok(orders);
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.ToString());
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> UpdateOrderStatus(int id, [FromQuery] string status = "")
        {
            try
            {
                await _orderService.UpdateOrderStatus(id, status);
                return Ok();
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.ToString());
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
