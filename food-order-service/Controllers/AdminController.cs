using food_order_service.Data_layer.DataModels;
using food_order_service.Models;
using food_order_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_order_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        [HttpPost("config")]
        [ProducesResponseType(201)]
        public async Task<ActionResult> AddNew([FromBody] SysConfigRequest sysConfigRequest)
        {
            try
            {
                await _adminService.AddNewConfigurationValue(sysConfigRequest.ConfigName, sysConfigRequest.ConfigValue);

                return StatusCode(201);
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

        [HttpGet("config")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ConfigOption>>> GetAll()
        {
            try
            {
                return Ok(await _adminService.GetSystemConfigurationValues());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }
    }
}
