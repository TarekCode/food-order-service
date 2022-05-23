using food_order_service.Data_layer.DataModels;
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
            return await _menuService.GetMenuItem(id);
        }

        [HttpGet]
        public async void GetAll()
        {
            
        }
    }
}
