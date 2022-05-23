using food_order_service.Data_layer;
using food_order_service.Data_layer.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace food_order_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private FoodServiceContext _foodServiceContext { get; set; }
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, FoodServiceContext foodServiceContext)
        {
            _logger = logger;
            _foodServiceContext = foodServiceContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //_foodServiceContext.MenuItems.Add(new MenuItem()
            //{
            //    Title = "Lamb Gyro",
            //    Description = "our classic gyro",
            //    Price = 8.99M,
            //    ItemOptions = new ItemOption[]
            //    {
            //        new ItemOption()
            //        {
            //            Name = "Pickles",
            //            IncludedByDefault = false,                        
            //        }
            //    }
            //});

            var item = _foodServiceContext.MenuItems.Find(1);
            item.Description = "some gyro";
            var asd = _foodServiceContext.SaveChangesAsync().Result;











            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}