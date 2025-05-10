using Okala.Application.DTOs;
using Okala.Domain;

namespace Okala.Application.Abstractions.Services;

public interface IWeatherService
{
    Task<WeatherAndAirQualityDto> GetWeatherAirQuality(string cityName, CancellationToken cancellationToken);
}