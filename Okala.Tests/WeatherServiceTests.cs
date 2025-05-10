using Microsoft.Extensions.Options;
using Okala.Application;
using Okala.Infrastructure.Services;

namespace Okala.Tests;

public class WeatherServiceTests
{
    private readonly WeatherService _service;

    public WeatherServiceTests()
    {
        var settings = new OpenWeatherMapSetting
        {
            ApiKey = "ee8692136f2d2341fcdb8570ae4a4314",
            BaseApiUrl = "http://api.openweathermap.org",
            CoordinatesByLocationNameUrl = "/data/2.5/weather",
            AirPollutionInfoByCordsUrl = "/data/2.5/air_pollution"
        };

        var options = Options.Create(settings);
        _service = new WeatherService(options);
    }

    [Fact]
    public async Task GetWeatherAirQuality_ShouldReturnResult()
    {
        var result = await _service.GetWeatherAirQuality("Tehran", CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(35.6944, result.Latitude);
        Assert.Equal(51.4215, result.Longitude);
    }
}