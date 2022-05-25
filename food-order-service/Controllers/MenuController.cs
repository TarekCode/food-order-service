using food_order_service.Data_layer.DataModels;
using food_order_service.Models;
using food_order_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_order_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly ILogger<MenuController> _logger;

        public MenuController(IMenuService menuService, ILogger<MenuController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<MenuItem>> GetItem(int id)
        {
            try
            {
                return await _menuService.GetMenuItem(id);
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.ToString());
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetAll()
        {
            try
            {
                return Ok(await _menuService.GetAllMenuItems());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put([FromBody] MenuItemRequest menuItemRequest)
        {
            try
            {
                await _menuService.AddOrUpdateMenuItem(menuItemRequest);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                await _menuService.DeleteMenuItem(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                _logger.LogWarning(e.ToString());
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }
    }
}
