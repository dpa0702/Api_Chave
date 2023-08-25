using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;

namespace Api_Chave.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("QualChave")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Retorno> QualChave([FromBody] Entrada entrada)
        {
            if (!String.IsNullOrEmpty(entrada.chave))
            {
                if (entrada.chave == "559e")
                {
                    return Enumerable.Range(1, 1).Select(index => new Retorno
                    {
                        ret = "OK"
                    }).ToArray();
                }
                else
                {
                    return Enumerable.Range(1, 1).Select(index => new Retorno
                    {
                        ret = "NOK"
                    }).ToArray();
                }
            }
            else
            {
                return Enumerable.Range(1, 1).Select(index => new Retorno
                {
                    ret = "FORA"
                }).ToArray();
            }
        }

        [HttpPost("QualChave2")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult QualChave2([FromBody] Entrada entrada)
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            if (!String.IsNullOrEmpty(entrada.chave))
            {
                if (entrada.chave == "559e")
                {
                    Response.StatusCode = StatusCodes.Status200OK;
                }
                else
                {
                    Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }
            else
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return new JsonResult(result);
        }
    }
}