using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlogPractice.Controllers
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
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            using (_logger.BeginScope(new Dictionary<string, object> { ["ActionKey"] = nameof(GetWeatherForecast) })) {


                _logger.LogInformation($"testing");

                //To test the exception Logging
                //var ex = new Exception();
                //ex.Data.Add("data1", "val2");
                //_logger.LogError(ex, "Stopped program because of exception");
                //throw ex;

                throw new ArgumentNullException();

                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
        }
    }
}
