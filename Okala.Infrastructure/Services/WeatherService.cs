using System.Globalization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Okala.Application;
using Okala.Application.Abstractions.Services;
using Okala.Application.DTOs;
using Okala.Domain.Entities;
using RestSharp;

namespace Okala.Infrastructure.Services;

public class WeatherService(IOptions<OpenWeatherMapSetting> options) : IWeatherService
{
    private readonly OpenWeatherMapSetting _openWeatherMapSetting = options.Value;

    /// <summary>
    /// Gives the given city's Weather information
    /// </summary>
    /// <param name="cityName"> Name of the city you want to get its weather</param>
    /// <param name="cancellationToken"></param>
    /// <returns>given city's Weather information</returns>
    /// <exception cref="ApplicationException"></exception>
    private async Task<WeatherInfo?> CoordinatesByLocationNameDetail(
        string cityName,
        CancellationToken cancellationToken)
    {
        var client = new RestClient(new RestClientOptions(_openWeatherMapSetting.BaseApiUrl));

        var resource = $"{_openWeatherMapSetting.BaseApiUrl}{_openWeatherMapSetting.CoordinatesByLocationNameUrl}";
        var request = new RestRequest(resource);

        request.AddQueryParameter("q", cityName);
        request.AddQueryParameter("units", "metric");
        request.AddQueryParameter("appid", _openWeatherMapSetting.ApiKey);

        var response = await client.ExecuteAsync(request, cancellationToken);

        var result = JsonConvert.DeserializeObject<WeatherInfo>(response.Content);
        Console.WriteLine((int)response.StatusCode);
        return (int)response.StatusCode switch
        {
            200 => result,
            404 => throw new ApplicationException("استان مورد نظر یافت نشد."),
            _ => throw new AppDomainUnloadedException("سرویس در حال حاضر در دسترس نیست")
        };
    }

    private async Task<AirPollutionInfo> GetInformationByLatitudeLongitudeDetail(
        string lat,
        string lon,
        CancellationToken cancellationToken)
    {
        var client = new RestClient(new RestClientOptions(_openWeatherMapSetting.BaseApiUrl));

        var resource = $"{_openWeatherMapSetting.BaseApiUrl}{_openWeatherMapSetting.AirPollutionInfoByCordsUrl}";
        var request = new RestRequest(resource);

        request.AddQueryParameter("lat", lat[..5].Replace("/", ","));
        request.AddQueryParameter("lon", lon[..5].Replace("/", ","));
        request.AddQueryParameter("appid", _openWeatherMapSetting.ApiKey);

        var response = await client.ExecuteAsync(request, cancellationToken);

        return JsonConvert.DeserializeObject<AirPollutionInfo>(response.Content);
    }


    public async Task<WeatherAndAirQualityDto> GetWeatherAirQuality(string cityName,
        CancellationToken cancellationToken)
    {
        var coordinates = await CoordinatesByLocationNameDetail(cityName, cancellationToken);

        var airQuality = (await GetInformationByLatitudeLongitudeDetail(
            coordinates.Coord.Lat.ToString(CultureInfo.InvariantCulture),
            coordinates.Coord.Lon.ToString(CultureInfo.InvariantCulture),
            cancellationToken)).List[0];

        var result = new WeatherAndAirQualityDto(
            coordinates.Coord.Lat,
            coordinates.Coord.Lon,
            coordinates.Main.Temp,
            coordinates.Main.Humidity,
            coordinates.Wind.Speed,
            airQuality.Main.Aqi,
            airQuality.Components.Co,
            airQuality.Components.No,
            airQuality.Components.No2,
            airQuality.Components.O3,
            airQuality.Components.So2,
            airQuality.Components.Pm25,
            airQuality.Components.Pm10,
            airQuality.Components.Nh3,
            cityName
        );
        return result;
    }
}