using Microsoft.AspNetCore.Mvc;
using Okala.Application.Abstractions.Services;

namespace Okala.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(
    IWeatherService weatherService
) : ControllerBase
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("WeatherAndAirQuality")]
    public async Task<IActionResult> GetWeatherAirQualityResponse(
        [FromQuery] string cityName,
        CancellationToken cancellationToken)
    {
        return Ok(await weatherService.GetWeatherAirQuality(cityName, cancellationToken));
    }

}