using Microsoft.AspNetCore.Mvc;
using OpusMastery.Domain.WeatherForecast;

namespace OpusMastery.Admin.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    [HttpGet("forecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        IEnumerable<WeatherForecast> result = Enumerable.Range(1, 5).Select(index =>  new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
        
        return Ok(result);
    }
}