using Microsoft.Extensions.DependencyInjection;
using Okala.Application.Abstractions.Services;
using Okala.Infrastructure.Services;

namespace Okala.Infrastructure.Configurations;

public static class ConfigureService
{
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWeatherService, WeatherService>();
    }
}