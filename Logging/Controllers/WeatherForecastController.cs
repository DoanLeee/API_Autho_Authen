using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            //_logger.Log(LogLevel.Information, "Hello From Wheather Controller ");
            //_logger.LogInformation("Hello again From Controller ");
            //_logger.LogWarning("This a waring");
            //try
            //{
            //    throw new Exception("This is a test ễcption");
            //}
            //catch (Exception ex) 
            //{
            //    _logger.LogError(ex, "Error in creating object");
            //}
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()

        {
            //_logger.LogInformation(1001,"Getting weather forecast details");
            //var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
